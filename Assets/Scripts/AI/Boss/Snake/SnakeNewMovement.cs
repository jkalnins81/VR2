using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNewMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public float lerp = 0.5f;
    public float forward = 0.25f;

    Animator animator;
    Rigidbody rb;

    Vector3 Vector3Forward;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("SnakeIdle", true);
        rb = gameObject.GetComponent<Rigidbody>();
        Vector3Forward = new Vector3(0, 0, forward);
        StartSnakeMovement();
    }

    void StartSnakeMovement()
    {
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3Forward, lerp) * speed;
    }
}
