using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDataPointsCollected : MonoBehaviour
{
    private int totalDatapoints = 0;
    int dataPointsInScene = 0;
    bool winCondition = false;

    VictoryHandler vh;

    public void Start()
    {
        //String reference needs to be changed if the DataPoint tag is ever changed in unity
        GameObject[] dataPoints = GameObject.FindGameObjectsWithTag("DataPoint");

        GameObject gob;
        gob = GameObject.Find("Player");
        vh = gob.GetComponent<VictoryHandler>();

        dataPointsInScene = dataPoints.Length;
        print(dataPointsInScene);

        totalDatapoints = 18; //test come back later
    }
    
    public void IncrementTotal()
    {
        totalDatapoints++;
    }

    public int GetTotalDataPoints()
    {
        return totalDatapoints;
    }

    public int GetPointsInScene()
    {
        return dataPointsInScene;
    }

    public void Update()
    {
        if (totalDatapoints == dataPointsInScene && !winCondition)
        {
            winCondition = true;
            vh.handleVictory();
        }
    }
}
