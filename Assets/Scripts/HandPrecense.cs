using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPrecense : MonoBehaviour
{
    private InputDevice _targetDevice;
    
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller; 

        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item  in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            _targetDevice = devices[0];
        }

        Debug.Log(_targetDevice);
    }
    
    void Update()
    {

        _targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryBottonValue);
        if (primaryBottonValue)
        {
            Debug.Log("Pressing Primary Button");
        }
    }
}
