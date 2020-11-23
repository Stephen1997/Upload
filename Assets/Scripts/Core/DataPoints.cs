using System.Collections;
using UnityEngine;

public class DataPoints : MonoBehaviour
{

    bool isTriggered = false;
    bool isInVicinity = false;
    float pressedTimer = 0f;

    [SerializeField] float downloadTime = 3f;

    private TotalDataPointsCollected tdp;

    public void Start()
    {
        GameObject gob;

        gob = GameObject.Find("DataPoints");
        tdp = gob.GetComponent<TotalDataPointsCollected>();
    }

    public void Update()
    {
        if (Input.GetKey("e") && isInVicinity && !isTriggered)
        {
            pressedTimer += Time.deltaTime;
            if (pressedTimer >= downloadTime)
            {
                isTriggered = true;
                pressedTimer = 0f;
                tdp.IncrementTotal();
                print(tdp.GetTotalDataPoints());
            }
        }
        else
        {
            pressedTimer = 0f;
        }
    }

    //Detects when player enters vicinity and sets isInVicinity to true
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInVicinity = true;
        }
    }

    //Detects when player exits vicinity and sets isInVicinity to false
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInVicinity = false;
        }
    }

}
