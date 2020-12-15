using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpots : MonoBehaviour
{
    EnemyAI enemyAi;

    [SerializeField] GameObject safeDoor;

    bool isTriggered = false;

    void Start()
    {
        GameObject gob;
        gob = GameObject.FindGameObjectWithTag("Enemy");
        enemyAi = gob.GetComponent<EnemyAI>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = true;
            enemyAi.SetAlertStatusToFalse();
            enemyAi.ReturnToPost();
            print("test1");
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
