using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    TotalDataPointsCollected tdp;

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    [SerializeField] float delay = 0f;
    int requiredDataPoints = 10;

    float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;

        GameObject gob;

        gob = GameObject.Find("DataPoints");
        tdp = gob.GetComponent<TotalDataPointsCollected>();
    }

    // Update is called once per frame
    void Update()
    {
        if (requiredDataPoints <= tdp.GetTotalDataPoints())
        {
            // todo protect against period is zero
            float cycles = Time.time / period + delay; // grows continually from 0

            const float tau = Mathf.PI * 2f; // about 6.28
            float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

            movementFactor = rawSinWave / 2f + 0.5f;
            Vector3 offset = movementFactor * movementVector;
            transform.position = startingPos + offset;
        }
            
    }
}
