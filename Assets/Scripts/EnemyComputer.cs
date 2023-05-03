
using UnityEngine;
using UnityEngine.AI;

public class EnemyComputer : MonoBehaviour
{

	public NavMeshAgent agent;

	public Transform player;

	public LayerMask whatIsGround, whatIsPlayer;

	public Vector3 walkPoint;
	public float walkPointRange;

	public float timeBetweenAttacks;
	bool alreadyAttacked = false;
	public GameObject projectile;

	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;

	public float lastDidSomething, pauseTime = 3f;
	
	[SerializeField]
	public Canvas gameOverScreen;
	[SerializeField]
	private EnemyLap lapScript;

	public int lapCount = 0;

	public int finalLapNumber = 4;

	private void Awake()
	{
		player = GameObject.Find("Enemy Tracker").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (Time.time < lastDidSomething + pauseTime) return;
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		if (playerInSightRange && !playerInAttackRange) ChasePlayer();
		if (playerInSightRange && playerInAttackRange) AttackPlayer();
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Enemy Tracker")
		{
			player = GameObject.Find("Enemy Tracker 2").transform;
		}

		if (collision.gameObject.name == "Enemy Tracker 2")
		{
			player = GameObject.Find("Enemy Tracker 3").transform;
		}

		if (collision.gameObject.name == "Enemy Tracker 3")
		{	
			player = GameObject.Find("Enemy Tracker 4").transform;
		}

		if (collision.gameObject.name == "Enemy Tracker 4")
		{
			player = GameObject.Find("Enemy Tracker 5").transform;
		}

		if (collision.gameObject.name == "Enemy Tracker 5")
		{
			player = GameObject.Find("Enemy Tracker").transform;
			lapCount++;
			if (lapCount >= finalLapNumber)
			{
				gameOverScreen.GetComponent<GameOverScreen>().Setup(lapScript.EnemyGetFastestTime());
			}
		}
		
	}


	private void ChasePlayer()
	{
		agent.SetDestination(player.position);
	}

	private void AttackPlayer()
	{
		agent.SetDestination(transform.position);

		transform.LookAt(player);

		if (!alreadyAttacked)
		{

			Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
			rb.AddForce(transform.up * 8f, ForceMode.Impulse);



			alreadyAttacked = true;

			Invoke("ResetAttack", timeBetweenAttacks);
		}

	}

	private void ResetAttack()
	{
		alreadyAttacked = false;
	}


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, sightRange);
	}
}
