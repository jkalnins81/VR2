using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscBehaviourRelease : MonoBehaviour
{
    public Rigidbody discRB;
    public ControllerVelocity controllerVelocity;

    public Collider collider;

    private float discMaxSpeed = 1;
    private float forceMultiplier = 10;
    
    private void Start()
    {
        discRB = GetComponent<Rigidbody>();
        controllerVelocity = FindObjectOfType<ControllerVelocity>();

        collider = GetComponent<Collider>();
    }

    public void ReleaseVelocity()
    {
        float handSpeed = controllerVelocity.rightHandRB.velocity.magnitude;

        if(handSpeed > discMaxSpeed)
        {
            Debug.Log(discMaxSpeed);
            discRB.AddForce(controllerVelocity.rightHandRB.velocity.normalized  * forceMultiplier, ForceMode.Impulse);
        }
        else
        {
            float discPercentage = handSpeed / discMaxSpeed;
            discRB.AddForce(controllerVelocity.rightHandRB.velocity.normalized * discPercentage * forceMultiplier, ForceMode.Impulse);
            
            Debug.Log(discPercentage);
        }
    }

    public void DisableDiscCollider()
    {
        collider.enabled = false; 
    }
    
    public void EnabaleDiscCollider()
    {
        collider.enabled = true; 
    }

}
