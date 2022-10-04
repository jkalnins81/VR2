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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc") || other.CompareTag("DiscHolding") || other.CompareTag("FrontWall"))
        {
            // instantitate VFX effect

            transform.parent.gameObject.SetActive(false);

            //Destroy(transform.parent.gameObject);
        }
    }
}
