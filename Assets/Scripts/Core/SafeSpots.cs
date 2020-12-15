using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpots : MonoBehaviour
{
    EnemyAI enemyAi;
    GameObject enemyPrefab;
    List<EnemyAI> enemyAis;


    [SerializeField] GameObject safeDoor;

    bool isTriggered = false;

    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); ;
        enemyAis = new List<EnemyAI>(); 

        foreach (GameObject enemy in enemies)
        {
            enemyAis.Add(enemy.GetComponent<EnemyAI>());
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;

            foreach (EnemyAI enemyAi in enemyAis)
            {
                enemyAi.SetAlertStatus(false);
                enemyAi.ReturnToPost();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }

    public bool GetIsTriggered()
    {
        return isTriggered;
    }
}
