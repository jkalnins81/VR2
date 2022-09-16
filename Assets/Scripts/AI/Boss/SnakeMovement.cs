using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed;
    public GameObject SnakeHead;
    public GameObject Snake1;
    public GameObject Snake2;
    public GameObject Snake3;
    public GameObject Snake4;
    public GameObject Snake5;
    public GameObject Snake6;
    public GameObject Snake7;
    public GameObject Snake8;
    public GameObject Snake9;
    public GameObject Snake10;


    private void Start()
    {
        StartCoroutine(StartSnakeMovement());
    }

    IEnumerator StartSnakeMovement()
    {
        SnakeHead.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake8.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake9.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward
        Snake10.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // move forward

        yield return new WaitForSeconds(1f);
        
    }
}
