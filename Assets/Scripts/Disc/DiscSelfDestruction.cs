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
    
    public void DiscPickedUp()
    {
        Debug.Log("Touched disc");
        holdingDisc = true;
    }
    
    public void DiscDropped()
    {
        Debug.Log("Dropped disc");
        holdingDisc = false; 
    }

    private void Update()
    {
        if (holdingDisc)
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
}
