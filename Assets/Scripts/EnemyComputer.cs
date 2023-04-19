
using UnityEngine;
using UnityEngine.AI;

public class EnemyComputer : MonoBehaviour
{

	public NavMeshAgent agent;

	public Transform player;

	public LayerMask whatIsGround, whatIsPlayer;

	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	public float timeBetweenAttacks;
	bool alreadyAttacked = false;
	public GameObject projectile;

	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;

	public float lastDidSomething, pauseTime = 3f;


	private void Awake()
    {
		player = GameObject.Find("Finish Line Collider").transform;
		agent = GetComponent<NavMeshAgent>();
    }

	private void Update()
    {
		if (Time.time < lastDidSomething + pauseTime) return;
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		if (!playerInSightRange && !playerInAttackRange) Patrolling();
		if (playerInSightRange && !playerInAttackRange) ChasePlayer();
		if (playerInSightRange && playerInAttackRange) AttackPlayer();

	}

	private void Patrolling()
    {
		if (!walkPointSet) SearchWalkPoint();

		if (walkPointSet)
			agent.SetDestination(walkPoint);

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		if (distanceToWalkPoint.magnitude < 1f)
			walkPointSet = false;

		lastDidSomething = Time.time;
    }

    private void SearchWalkPoint()
    {
		float randomZ = Random.Range(-walkPointRange, walkPointRange);
		float randomX = Random.Range(-walkPointRange, walkPointRange);

		walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

		if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
			walkPointSet = true;
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
