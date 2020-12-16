using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpots : MonoBehaviour
{
    EnemyAI enemyAi;
    GameObject enemyPrefab;
    List<EnemyAI> enemyAis;


    [SerializeField] GameObject safeDoor;
    [SerializeField] float movementSpeed = 10f;

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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            SafetyDoor(true);

            foreach (EnemyAI enemyAi in enemyAis)
            {
                enemyAi.SetAlertStatus(false);
                enemyAi.ReturnToPost();
            }
        }
    }

    private void SafetyDoor(bool state)
    {
        if (state)
        {
            safeDoor.transform.position = new Vector3(safeDoor.transform.position.x, safeDoor.transform.position.y + 5, safeDoor.transform.position.z);
        }
        else
        {
            safeDoor.transform.position = new Vector3(safeDoor.transform.position.x, safeDoor.transform.position.y - 5, safeDoor.transform.position.z);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        SafetyDoor(false);
    }

    public bool GetIsTriggered()
    {
        return isTriggered;
    }
}
