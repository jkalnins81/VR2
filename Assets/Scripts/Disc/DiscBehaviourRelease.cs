using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiscBehaviourRelease : MonoBehaviour
{
    public Rigidbody discRB;
    public ControllerVelocity controllerVelocity;

    public Collider collider;

    private float controllerMaxSpeed = 0.5f;
    private float forceMultiplier = 100;

    public XRGrabInteractable thisXRGrabInteractable;
    
    private void Start()
    {
        discRB = GetComponent<Rigidbody>();
        controllerVelocity = FindObjectOfType<ControllerVelocity>();

        collider = GetComponent<Collider>();
        thisXRGrabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void ReleaseVelocity()
    {
        float handSpeed = controllerVelocity.rightHandRB.velocity.magnitude;
        
        if(handSpeed >= controllerMaxSpeed)
        {
            Debug.Log("Using max Speed");

            //Cap the max throw speed vel
            //Start coroutine and add force after the XR scripts adds it's own throw velocity 
            StartCoroutine(AddForceAfterThrow());
        }
        else
        {
            Debug.Log("Using Low speed");
            // if arm movement is slow, output this 
            // float discPercentage = handSpeed / discMaxSpeed;
            // Debug.Log(discPercentage);
            thisXRGrabInteractable.throwVelocityScale = 1.0f;
            discRB.AddForce(controllerVelocity.rightHandRB.velocity.normalized, ForceMode.Impulse);
            
  
        }

    }

    public void DisableDiscCollider()
    {
        //Disable collider from controller script 
        collider.enabled = false; 
    }
    
    public void EnabaleDiscCollider()
    {
        //Enable collider from controller script 
        StartCoroutine(DiscColliderOn());
    }

    IEnumerator DiscColliderOn()
    {
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true; 
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
