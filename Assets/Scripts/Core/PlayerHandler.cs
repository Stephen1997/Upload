using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    bool isDead = false;

    public bool IsDead()
    {
        isDead = true;
        return isDead;
    }
}
