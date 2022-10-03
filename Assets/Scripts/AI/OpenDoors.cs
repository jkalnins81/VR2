using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float lerp = 0.5f;
    public float speed = 1.5f;

    public bool leftDoorClosing = false;
    public bool rightDoorClosing = false;

    private Rigidbody leftDoorRB;
    private Rigidbody rightDoorRB;

    private void Start()
    {
        leftDoorRB = leftDoor.GetComponent<Rigidbody>();
        rightDoorRB = rightDoor.GetComponent<Rigidbody>();
    }

    public void openingDoors()
    {
        leftDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(leftDoorRB.velocity, Vector3.right, lerp) * speed;
        rightDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(rightDoorRB.velocity, -Vector3.right, lerp) * speed;
    }

    public void closingDoors()
    {
        leftDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(leftDoorRB.velocity, -Vector3.right, lerp * 2) * speed;
        rightDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(rightDoorRB.velocity, Vector3.right, lerp * 2) * speed;
        leftDoorClosing = true;
        rightDoorClosing = true;
    }

    private void Update()
    {
        if(leftDoor.transform.localPosition.z >= 2.5f)
        {
            leftDoorRB.velocity = new Vector3(0, 0, 0);
        }

        if(rightDoor.transform.localPosition.z <= -2.5f)
        {
           rightDoorRB.velocity = new Vector3(0, 0, 0);
        }

        if(leftDoorClosing && leftDoor.transform.localPosition.z <= 0f) 
        {
            leftDoorRB.velocity = new Vector3(0, 0, 0);
            leftDoorClosing = false;
        }

        if (rightDoorClosing && rightDoor.transform.localPosition.z >= 0f)
        {
            rightDoorRB.velocity = new Vector3(0, 0, 0);
            rightDoorClosing = false;
        }
    }
}
