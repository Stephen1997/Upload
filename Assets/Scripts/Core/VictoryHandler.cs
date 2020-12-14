using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryHandler : MonoBehaviour
{
    [SerializeField] Canvas youWinCanvas;

    void Start()
    {
        youWinCanvas.enabled = false;
    }

    public void handleVictory()
    {
        youWinCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.visible = true;
    }
}
