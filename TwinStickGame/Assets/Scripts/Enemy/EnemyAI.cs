using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;
    public float enemyHealth;
    [Header("Patrol State")]
    [SerializeField] Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;
    [SerializeField] float patrolPointTimer;
    private float patrolTimer;
    [Header("Attack Settings")]
    [SerializeField] int dmg;
    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;
    [Header("States")]
    [SerializeField] float sightRange, attackRange;
    bool isPlayerInSightRange;
    bool isPlayerInAttackRange;


 
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        isPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isPlayerInSightRange && !isPlayerInAttackRange)
        {
            Patroling();
        }

        if(isPlayerInSightRange && !isPlayerInAttackRange)
        {
            Chasing();
        }
        if(isPlayerInSightRange && isPlayerInAttackRange)
        {
            Attack();
        }
    }

    private void Patroling()
    {

        patrolTimer += Time.deltaTime;

        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walk point Reached

        if(distanceToWalkPoint.magnitude < 1f || patrolTimer >= patrolPointTimer)
        {
            walkPointSet = false;
            patrolTimer = 0f;
        }

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

         if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }
    private void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(dmg);
            /////Attack code here!!!!

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
