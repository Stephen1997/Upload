using System.Collections;
using UnityEngine;

public class DataPoints : MonoBehaviour
{
    int totalDataPoints = 0;
    bool isTriggered = false;
    [SerializeField] float downloadTime = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isTriggered)
        {
            StartCoroutine(TimeOfDownload());
        }
    }
    
    private IEnumerator TimeOfDownload()
    {
        print("first check " + totalDataPoints); 
        yield return new WaitForSeconds(downloadTime);
        print("second check " + totalDataPoints);
        DataPointCollected();
        isTriggered = true;
        print("Player made contact " + totalDataPoints);
    }

    private void DataPointCollected()
    {
        totalDataPoints++;
    }
}
