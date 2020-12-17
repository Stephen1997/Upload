using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            KillEnemyMinion();
            print("killing");
        }
    }

    private void KillEnemyMinion()
    {
        Destroy(gameObject);
    }
}
