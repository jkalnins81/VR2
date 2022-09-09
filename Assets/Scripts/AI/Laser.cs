using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int speed;
    GameObject AIEnemy;

    void Start()
    {
        Destroy(this, 3);
        AIEnemy = GameObject.FindGameObjectWithTag("AIEnemy");
        this.GetComponent<Rigidbody>().velocity = AIEnemy.transform.forward * speed;
    }
}
