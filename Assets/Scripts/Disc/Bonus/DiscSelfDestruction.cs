using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiscSelfDestruction : MonoBehaviour
{
    public bool holdingDisc;
    public float discSelfDestructTimer = 3.0f;
    
    public GameObject particleSystemDestroy;

    private DiscPillar discPillar;



    private void Update()
    {
        discSelfDestructTimer -= Time.deltaTime;

            if (discSelfDestructTimer <= 0)
            {
                GameObject particles = Instantiate(particleSystemDestroy, transform.position, quaternion.identity);
                Destroy(particles, 1f);
                Destroy(gameObject);
            }
        }
    }
