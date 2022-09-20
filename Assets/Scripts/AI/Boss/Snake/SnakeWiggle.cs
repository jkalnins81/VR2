using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWiggle : MonoBehaviour
{
    [SerializeField] private float frequency = 5f;

    [SerializeField] private float magnitude = 0.01f;

    [SerializeField] private float offset = 0f;

    private void Update()
    {
        transform.position = transform.position + transform.right * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
}
