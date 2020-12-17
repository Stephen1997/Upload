using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    TotalDataPointsCollected tdp;
    
    [SerializeField] int requiredDataPoints;

    private void Start()
    {
        GameObject gob;

        gob = GameObject.Find("DataPoints");
        tdp = gob.GetComponent<TotalDataPointsCollected>();
    }

    private void Update()
    {
       if(requiredDataPoints <= tdp.GetTotalDataPoints())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
        }
    }
}
