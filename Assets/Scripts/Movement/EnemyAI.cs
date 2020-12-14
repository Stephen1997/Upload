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

    void Start()
    {
        GameObject gob;
        gob = GameObject.Find("Player");
        ph = gob.GetComponent<DeathHandler>();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= chaseRange && !isDead)
        {
            navMeshAgent.SetDestination(target.position); 
            
            if (distanceToTarget <= killRange)
            {
                Explode();
                ph.IsDead();                
            }            
        }
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
