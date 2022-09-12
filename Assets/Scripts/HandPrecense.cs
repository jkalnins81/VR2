using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.XR.Interaction.Toolkit.XRController;

public class HandPrecense : MonoBehaviour
{
    public Transform target;
    private Rigidbody _rb;

    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.0005f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > showNonPhysicalHandDistance)
        {
            nonPhysicalHand.enabled = true;
        }
        else
        {
            nonPhysicalHand.enabled = false;
        }
        
        Debug.Log(distance);
    }

    void FixedUpdate()
    {
        // Pos
        _rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;
        
        // Rot
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        _rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);



    }
}
