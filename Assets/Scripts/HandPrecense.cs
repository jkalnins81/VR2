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
    [SerializeField] private  XRController controller;
    
    void Start()
    {
        // List<InputDevice> devices = new List<InputDevice>();
        // InputDeviceCharacteristics rightControllerCharacteristics = 
        //     InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller; 
        //
        // InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        //
        // foreach (var item  in devices)
        // {
        //     Debug.Log("hi");
        //     Debug.Log(item.name + item.characteristics);
        // }
        //
        // if (devices.Count > 0)
        // {
        //     _targetDevice = devices[0];
        // }
        // else Debug.Log("No devises found");

        // Debug.Log(devices);
    }
    
    void Update()
    {
        controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed);
        Debug.Log(isPressed);
       
        // controller.inputDevice.(CommonUsages.triggerButton, out bool primaryBottonValue);
        //     if (primaryBottonValue)
        //         Debug.Log("Pressing Primary Button");
        //
        //
        // _targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        //     if (triggerValue > 0.1f)
        //         Debug.Log("Trigger pressed " + triggerValue);
        //
        // _targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        //     if (primary2DAxisValue != Vector2.zero)
        //         Debug.Log("Primary Touchpad " + primary2DAxisValue);
        //     
            
            
    }
}
