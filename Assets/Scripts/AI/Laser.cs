using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int speed;
    GameObject AIEnemy;

    void Start()
    {
        AIEnemy = GameObject.FindGameObjectWithTag("AIEnemy");
        this.GetComponent<Rigidbody>().velocity = AIEnemy.transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FrontWall"))
        {
            Destroy(transform.parent.gameObject);
        }
    }

}
