using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed;
    public float movementDelay;

    float left = -1f;
    float right = 1f;
    float up = 1f;
    float down = -1f;
    float forward = 1f;
    float backward = -1f;

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
        // move forward

        SnakeHead.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed; 
        Snake1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake5.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake6.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake7.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake8.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake9.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;
        Snake10.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed;

        yield return new WaitForSeconds(0.5f);
        
        // move forward & up & right

        SnakeHead.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed; 
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = new Vector3(right, up, forward) * speed;

        yield return new WaitForSeconds(0.5f);

        // move forward & down & left

        SnakeHead.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = new Vector3(left, down, forward) * speed;

    }
}
