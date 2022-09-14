using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiscBehaviourRelease : MonoBehaviour
{
    public Rigidbody discRB;
    public ControllerVelocity controllerVelocity;

    public Collider[] colliders;

    private float controllerMaxSpeed = 0.5f;
    private float forceMultiplier = 100;

    public XRGrabInteractable thisXRGrabInteractable;

    public DiscPillar DiscPillar;

    private void Start()
    {
        discRB = GetComponent<Rigidbody>();
        controllerVelocity = FindObjectOfType<ControllerVelocity>();

        colliders = GetComponentsInChildren<Collider>();
        thisXRGrabInteractable = GetComponent<XRGrabInteractable>();

        DiscPillar = FindObjectOfType<DiscPillar>();

    }

    public void ReleaseVelocity()
    {
        float handSpeed = controllerVelocity.rightHandRB.velocity.magnitude;

        DiscPillar.spawnNewDiscBool = true; 
        
        if(handSpeed >= controllerMaxSpeed)
        {
            Debug.Log("Using max Speed");

            //Cap the max throw speed vel
            //Start coroutine and add force after the XR scripts adds it's own throw velocity 
            StartCoroutine(AddForceAfterThrow());
            //Spawn new disc from pillar
            DiscPillar.SpawnNewDiscDelay(1f);
        }
        else
        {
            Debug.Log("Using Low speed");
            // if arm movement is slow, output this 
            // float discPercentage = handSpeed / discMaxSpeed;
            // Debug.Log(discPercentage);
            thisXRGrabInteractable.throwVelocityScale = 1.0f;
            discRB.AddForce(controllerVelocity.rightHandRB.velocity.normalized, ForceMode.Impulse);
            //Spawn new disc from pillar
            DiscPillar.SpawnNewDiscDelay(1f); 
  
        }

    }

    public void DisableDiscCollider()
    {
        //Disable collider from controller script 
        colliders[0].enabled = false; 
        colliders[1].enabled = false; 
    }
    
    public void EnabaleDiscCollider()
    {
        //Enable collider from controller script 
        StartCoroutine(DiscColliderOn());
    }

    IEnumerator DiscColliderOn()
    {
        yield return new WaitForSeconds(0.5f);
        colliders[0].enabled = true; 
        colliders[1].enabled = true; 
    }


    IEnumerator AddForceAfterThrow()
    {
        //Ads force to the disc once it is released and has got the velocity from the controller 
        yield return new WaitForSeconds(0.01f);
        thisXRGrabInteractable.throwVelocityScale = 50f;
        thisXRGrabInteractable.throwAngularVelocityScale = 10.0f;
        discRB.AddForce(controllerVelocity.rightHandRB.velocity.normalized  * forceMultiplier, ForceMode.Impulse);
        
    }
}
