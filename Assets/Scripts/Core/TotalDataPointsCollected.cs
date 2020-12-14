using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDataPointsCollected : MonoBehaviour
{
    private int totalDatapoints = 0;
    int dataPointsInScene = 0;
    bool winCondition = false;

    public void Start()
    {
        //String reference needs to be changed if the DataPoint tag is ever changed in unity
        GameObject[] dataPoints = GameObject.FindGameObjectsWithTag("DataPoint");

        dataPointsInScene = dataPoints.Length;
        print(dataPointsInScene);
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
            LevelWinHandler();
        }
    }

    public void LevelWinHandler()
    {
        print("You Win");
    }
}
