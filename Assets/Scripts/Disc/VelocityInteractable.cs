using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VelocityInteractable : XRGrabInteractable
{
    private ControllerVelocity _controllerVelocity = null;
    private MeshRenderer meshRenderer = null; 
   
    void Awake()
    {
        _controllerVelocity = FindObjectOfType<ControllerVelocity>();
    }

    void ColorVelocity()
    {
        
    }


}
