using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        StartCoroutine(StartSnakeMovement());
    }

    IEnumerator StartSnakeMovement()
    {

        yield return new WaitForSeconds(1f);
        
    }
}
