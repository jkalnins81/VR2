using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] float speed = 280;
    [SerializeField] float turnSpeed = 18;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();

    private void Start()
    {
        GameObject temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
        if (!temp.GetComponent<MarkerManager>())
            temp.AddComponent<MarkerManager>();
        if(!temp.GetComponent<Rigidbody>())
        {
            temp.AddComponent<Rigidbody>();
            temp.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void SnakeMovement()
    {
        snakeBody[0].GetComponent<Rigidbody>().velocity = snakeBody[0].transform.forward * speed * Time.deltaTime;
    }
}
