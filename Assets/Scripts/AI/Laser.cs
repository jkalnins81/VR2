using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int speed;
    public int damage;
    GameObject AIEnemy;

    void Start()
    {
        AIEnemy = GameObject.FindGameObjectWithTag("AIEnemy");
        this.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc") || other.CompareTag("DiscHolding"))
        {
            // instantitate VFX effect

            transform.parent.gameObject.SetActive(false);

            //Destroy(transform.parent.gameObject);
        }
    }
}
