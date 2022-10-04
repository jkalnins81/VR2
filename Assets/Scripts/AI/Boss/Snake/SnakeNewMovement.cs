using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNewMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public float lerp = 0.5f;

    public float left = -1f;
    public float right = 1f;
    public float up = 1f;
    public float down = -1f;
    public float forward = 0.25f;

    public float secsToNewMovement = 2f;

    Animator animator;
    Rigidbody rb;

    Vector3 Vector3Forward;
    Vector3 Vector3Left;
    Vector3 Vector3Right;
    Vector3 Vector3UpLeft;
    Vector3 Vector3UpRight;
    Vector3 Vector3DownLeft;
    Vector3 Vector3DownRight;

    private void Awake()
    {
        transform.SetPositionAndRotation(new Vector3(7f, 1.98f, -18f), Quaternion.identity); // override EnemyWaveSpawner spawn position
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();

        Vector3Forward = new Vector3(0, 0, forward);
        Vector3Left = new Vector3(left, 0, forward);
        Vector3Right = new Vector3(right, 0, forward);
        Vector3UpLeft = new Vector3(left, up, forward);
        Vector3UpRight = new Vector3(right, up, forward);
        Vector3DownLeft = new Vector3(left, down, forward);
        Vector3DownRight = new Vector3(right, down, forward);
        
        StartCoroutine(StartSnakeMovement());
    }

    IEnumerator StartSnakeMovement()
    {
        // snake forward

        animator.SetBool("SnakeIdle", true);
        animator.SetBool("SnakeUp", false);
        animator.SetBool("SnakeDown", false);

        rb.velocity = Vector3.Lerp(rb.velocity, Vector3Forward, lerp) * speed;

        yield return new WaitForSeconds(secsToNewMovement);

        // snake forward, up & right

        animator.SetBool("SnakeIdle", false);
        animator.SetBool("SnakeUp", true);
        animator.SetBool("SnakeDown", false);

        rb.velocity = Vector3.Lerp(rb.velocity, Vector3UpRight, lerp) * speed;

        yield return new WaitForSeconds(secsToNewMovement);

        // snake forward, down & left

        animator.SetBool("SnakeIdle", false);
        animator.SetBool("SnakeUp", false);
        animator.SetBool("SnakeDown", true);

        rb.velocity = Vector3.Lerp(rb.velocity, Vector3DownLeft, lerp) * speed;

        yield return new WaitForSeconds(secsToNewMovement);

        // snake forward, left

        animator.SetBool("SnakeIdle", true);
        animator.SetBool("SnakeUp", false);
        animator.SetBool("SnakeDown", false);

        rb.velocity = Vector3.Lerp(rb.velocity, Vector3Left, lerp) * speed;

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & right

        animator.SetBool("SnakeIdle", true);
        animator.SetBool("SnakeUp", false);
        animator.SetBool("SnakeDown", false);

        rb.velocity = Vector3.Lerp(rb.velocity, Vector3Right, lerp) * speed;

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & down & right

        animator.SetBool("SnakeIdle", false);
        animator.SetBool("SnakeUp", false);
        animator.SetBool("SnakeDown", true);

        rb.velocity = Vector3.Lerp(rb.velocity, Vector3DownRight, lerp) * speed;

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & up & left

        animator.SetBool("SnakeIdle", false);
        animator.SetBool("SnakeUp", true);
        animator.SetBool("SnakeDown", false);

        rb.velocity = Vector3.Lerp(rb.velocity, Vector3UpLeft, lerp) * speed;


    }
}
