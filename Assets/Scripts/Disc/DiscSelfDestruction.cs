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

    private void Start()
    {
        discPillar = FindObjectOfType<DiscPillar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hands")
        holdingDisc = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hands")
        holdingDisc = false;
    }
    

    private void Update()
    {
        if (holdingDisc)
        {
            discSelfDestructTimer -= Time.deltaTime;

            if (discSelfDestructTimer <= 0)
            {
                //spawn new pillar
                discPillar.DeActivatePillar();
                discPillar.spawnNewDiscBool = true;
                discPillar.SpawnNewDiscDelay(1f); 
                GameObject particles = Instantiate(particleSystemDestroy, transform.position, quaternion.identity);
                Destroy(particles, 1f);
                Destroy(gameObject);
            }
        }
    }
}
