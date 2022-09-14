using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;

    // AI moves slowly && smoothly towards the player over time

    private void Start()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }

    // AI moves up/down && left/right towards the player over time
}
