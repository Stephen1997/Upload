using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UPLOAD.Core
{
    public class TotalDataPointsCollected : MonoBehaviour
    {
        private int totalDatapoints = 0;
        int dataPointsInScene = 0;

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

        void Start()
        {
            //String reference needs to be changed if the DataPoint tag is ever changed in unity
            GameObject[] dataPoints = GameObject.FindGameObjectsWithTag("DataPoint");

            dataPointsInScene = dataPoints.Length;
        }
    }
}
