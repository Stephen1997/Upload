using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] GameObject explosionEffect;
    
    bool isDead = false;

    public void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public bool IsDead()
    {
        Explode();
        Invoke("HandleDeath", 2);

        isDead = true;
        return isDead;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //Destroy(gameObject);
    }


}
