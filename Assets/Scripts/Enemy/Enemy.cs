using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject attackSphere;
    [SerializeField] Transform sensePoint;
    private charaterManager manager;
    private float speed = 0;
    private Transform lastPosition;

    int wave = 1;

    public LayerMask whatIsGround, whatIsPlayer;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    Animator anim;

    //states
    public float attackRange;
    public bool playerInAttackRange;
    public bool isMoving = false;

	private void Awake()
	{
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        manager = GetComponent<charaterManager>();
        anim = GetComponent<Animator>();
        manager.SetHealth(wave);

        lastPosition = transform;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(sensePoint.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) anim.SetTrigger("Attack");

        //update speed
        speed = (transform.position - lastPosition.position).magnitude / Time.deltaTime;
        lastPosition.position = transform.position;
        anim.SetFloat("Speed", speed);

	}

	private void ChasePlayer()
    {
        anim.SetBool("Moving", true);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        anim.SetBool("Moving", false);
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
			//attack code
			Instantiate(attackSphere, attackPoint);

			anim.SetTrigger("Attack");
            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }

    private void resetAttack()
    {
        alreadyAttacked = false;
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

    public void AttackSphere()
    {
		
	}
}
