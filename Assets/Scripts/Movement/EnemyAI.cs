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

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isDead = false;
    bool isAlert = false;

    Vector3 guardPosition;

    void Start()
    {
        GameObject gob;
        gob = GameObject.Find("Player");
        dh = gob.GetComponent<DeathHandler>();

        guardPosition = transform.position;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        print(guardPosition + " guard position during update");


        //alert a dude
        if (distanceToTarget <= chaseRange && !isDead)
        {
            isAlert = true;
        }

        //chase a dude
        if (isAlert == true)
        {
            ChasePlayer();
            //print(isAlert);
        }
    }

    public void ChasePlayer()
    {
        navMeshAgent.SetDestination(target.position);

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
        //isAlert = false;
        print(guardPosition + " guard position after stepping on plate");
        navMeshAgent.SetDestination(guardPosition);
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
