using Newtonsoft.Json.Bson;
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

    public GameManager gManager;

	GameObject closetObject;

	int playerIndex = 0;

    int wave = 1;

    private float oldDistance = 0;

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
        player = GameObject.Find("MultiplayerPlayer(Clone)").transform;
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        //FindNearestPlayer();
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
        if (player != null) agent.SetDestination(player.position);
        else Debug.Log("Where the Fuck is the player");
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

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
	}

    public void AttackSphere()
    {
		
	}

    public void setPlayerIndex(int index)
    {
        playerIndex = index;
    }

	public void OnDestroy()
	{
        gManager.EnemyDied(playerIndex);
	}

	//private void FindNearestPlayer()
	//{
	//	foreach (GameObject g in gManager.Players)
	//	{
 //           if(g != null)
 //           {
	//		    float distance = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
	//		    if (distance < oldDistance)
	//		    {
 //                   player = g.transform;
	//			    oldDistance = distance;
	//		    }
 //           }
	//	}
	//}
}
