using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float lerp = 0.5f;
    public float speed = 1.5f;

    //bool doorsOpen = false;
    bool leftDoorClosing = false;
    bool rightDoorClosing = false;


    public void openingDoors()
    {
        leftDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(leftDoor.GetComponent<Rigidbody>().velocity, Vector3.right, lerp) * speed;
        rightDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(rightDoor.GetComponent<Rigidbody>().velocity, -Vector3.right, lerp) * speed;
        //doorsOpen = true;
    }

    public void closingDoors()
    {
        leftDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(leftDoor.GetComponent<Rigidbody>().velocity, -Vector3.right, lerp * 2) * speed;
        rightDoor.GetComponent<Rigidbody>().velocity = Vector3.Lerp(rightDoor.GetComponent<Rigidbody>().velocity, Vector3.right, lerp * 2) * speed;
        leftDoorClosing = true;
        rightDoorClosing = true;
    }

    private void Update()
    {
        if(leftDoor.transform.localPosition.z >= 2.5f)
        {
            leftDoor.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if(rightDoor.transform.localPosition.z <= -2.5f)
        {
            rightDoor.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if(leftDoorClosing && leftDoor.transform.localPosition.z <= 0f) 
        {
            leftDoor.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            leftDoorClosing = false;
        }

        if (rightDoorClosing && rightDoor.transform.localPosition.z >= 0f)
        {
            rightDoor.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            rightDoorClosing = false;
        }
    }
}
