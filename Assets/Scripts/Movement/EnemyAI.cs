using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    DeathHandler ph;

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float killRange = 2f;

    [SerializeField] GameObject explosionEffect;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isDead = false;
    bool isAlert = false;
    bool isChasing = false;

    Vector3 guardPosition;

    void Start()
    {
        GameObject gob;
        gob = GameObject.Find("Player");
        ph = gob.GetComponent<DeathHandler>();

        guardPosition = transform.position;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        //alert a dude
        if (distanceToTarget <= chaseRange && !isDead)
        {
            isAlert = true;
        }

        //explode a dude
        if (distanceToTarget <= killRange)
        {
            Explode();
            ph.KillPlayer();
        }

        print(guardPosition); //testing

        //chase a dude
        if (isAlert == true)
        {
            ChasePlayer();
            print(isAlert);
        }
    }

    public void SetAlertStatusToFalse()
    {
        isAlert = false;
    }

    public void ReturnToPost()
    {
        //isAlert = false;
        print(guardPosition + "+");
        //navMeshAgent.SetDestination(guardPosition);
    }

    public void ChasePlayer()
    {
        navMeshAgent.SetDestination(target.position);
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
