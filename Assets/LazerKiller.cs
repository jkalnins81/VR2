using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AILaser")
        {
            other.enabled = false;
        }

        if (other.tag == "AIEnemy")
        {
            Destroy(other);
        }
    }
}
