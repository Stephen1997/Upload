using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    DeathHandler dh;

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float killRange = 2f;

    [SerializeField] GameObject explosionEffect;
    [SerializeField] PatrolPath patrolPath;
    [SerializeField] float waypointTolerance = 1.2f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isDead = false;
    bool isAlert = false;

    Vector3 guardPosition;
    int currentWaypointIndex = 0;

    void Start()
    {
        GameObject player;
        player = GameObject.Find("Player");
        dh = player.GetComponent<DeathHandler>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        guardPosition = transform.position;

        if (patrolPath != null)
        {
            Mover(GetCurrentWaypoint());
        }

        //PatrolBehaviour();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        //alert a dude
        if (distanceToTarget <= chaseRange && !isDead)
        {
            isAlert = true;
        }

        //chase a dude
        if (isAlert == true)
        {
            ChasePlayer();
        }

        if (AtWaypoint())
        {
            PatrolBehaviour();
            print("Running patrol");
        }
        print(currentWaypointIndex);
        print(transform.position);
        print(GetCurrentWaypoint());
    }

    public void Mover(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }

    public void ChasePlayer()
    {
        Mover(target.position);

        //explode a dude
        if (distanceToTarget <= killRange)
        {
            Explode();
            dh.KillPlayer();
        }
    }

    public void SetAlertStatus(bool status)
    {
        isAlert = status;
    }

    public void ReturnToPost()
    {
        if (patrolPath != null)
        {
            Mover(GetCurrentWaypoint());
        }
        else
        {
            Mover(guardPosition);
        }
    }    

    public void PatrolBehaviour()
    {
        Vector3 nextPosition = guardPosition;
        print("test 1");
        if(patrolPath != null)
        {
            print("test 2");
            if (AtWaypoint())
            {
                print("test3");
                CycleWaypoint();
            }
            nextPosition = GetCurrentWaypoint();
        }
        Mover(nextPosition);
    }

    public Vector3 GetCurrentWaypoint()
    {
        if (patrolPath == null)
        {
            return guardPosition;
        }
        else
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }
    }

    private void CycleWaypoint()
    {
        currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
    }

    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWaypoint <= waypointTolerance;
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        isDead = true;
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
