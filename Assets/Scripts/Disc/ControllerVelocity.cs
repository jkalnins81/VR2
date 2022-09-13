using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerVelocity : MonoBehaviour
{
    public Rigidbody leftHandRB;
    public Rigidbody rightHandRB;

    private void Update()
    {
        Debug.Log(LeftHandVelocity());
        Debug.Log(RightHandVelocity());
    }

    Vector3 LeftHandVelocity()
    {
        return leftHandRB.velocity;
    }
    
    Vector3 RightHandVelocity()
    {
    
        return rightHandRB.velocity;
        
    }
}
