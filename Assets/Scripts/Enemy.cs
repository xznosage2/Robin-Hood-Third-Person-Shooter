using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float attackRange;
    public bool playerInAttackRange;

	private void Awake()
	{
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //makes enemies stop moving when attacked
        //agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //attack code

            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }

    private void resetAttack()
    {
        alreadyAttacked = false;
    }

    private void TakeDamage()
    {

    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
