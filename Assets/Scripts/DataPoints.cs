using System.Collections;
using UnityEngine;

public class DataPoints : MonoBehaviour
{
    int totalDataPoints = 0;
    bool isTriggered = false;
    bool isInVicinity = false;
    float pressedTimer = 0f;

    [SerializeField] float downloadTime = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isTriggered)
        {
            isInVicinity = true;
        }
    }

    public void Update()
    {
        if (Input.GetKey("e") && isInVicinity && !isTriggered)
        {
            pressedTimer += Time.deltaTime;
            if (pressedTimer >= downloadTime)
            {
                totalDataPoints++;
                isTriggered = true;
                print("Player made contact " + totalDataPoints);
            }
        }
        else
        {
            pressedTimer = 0f;
        }
    }

}
