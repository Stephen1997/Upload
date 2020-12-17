using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBlast : MonoBehaviour
{
    [SerializeField] GameObject particleEffect;
    [SerializeField] float lifetime;

    GameObject particleEffectInstance;
    bool isShocking = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("shocking");
            particleEffectInstance = Instantiate(particleEffect, transform.position, transform.rotation);
            isShocking = true;
        }

        if (isShocking && particleEffectInstance != null)
        {
            particleEffectInstance.transform.position = transform.position;
            DestroyParticleEffect();
        }
    }

    private void DestroyParticleEffect()
    {
        Destroy(particleEffectInstance, lifetime);
    }
}
