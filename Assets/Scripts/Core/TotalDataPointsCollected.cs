using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalDataPointsCollected : MonoBehaviour
{
    private int totalDatapoints = 0;
    int dataPointsInScene = 0;
    bool winCondition = false;

    VictoryHandler vh;

    [SerializeField] GameObject scoreText;
    AudioSource collectSound;

    public void Start()
    {
        //String reference needs to be changed if the DataPoint tag is ever changed in unity
        GameObject[] dataPoints = GameObject.FindGameObjectsWithTag("DataPoint");

        GameObject gob;
        gob = GameObject.Find("Player");
        vh = gob.GetComponent<VictoryHandler>();

        dataPointsInScene = dataPoints.Length;
        print(dataPointsInScene);

        collectSound = GetComponent<AudioSource>();

        //totalDatapoints = 18; //test come back later
    }
    
    public void IncrementTotal()
    {
        totalDatapoints++;
        print("gsreg");
        collectSound.Play();
        scoreText.GetComponent<TextMeshProUGUI>().text = "Total Datpoints Collected: " + GetTotalDataPoints();
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
