using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    [SerializeField] float stoppingDistance = 2;
    [SerializeField] float minimunMovingDistance = 30;
    [SerializeField] GameObject enemy;



    private void Start()
    {
        GetRefrences();
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= minimunMovingDistance)
        {
            MoveToTarget();

        }

    }


    private void MoveToTarget()
    {
        agent.SetDestination(target.position);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= stoppingDistance)
        {
            //Attack 
            Debug.Log("Attack");
            
            RotateTotarget();


            // Temporal Crowd Control. 
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(enemy);
            }
        }

    }


    private void RotateTotarget()
    {
        transform.LookAt(target);
    }



    private void GetRefrences()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}
