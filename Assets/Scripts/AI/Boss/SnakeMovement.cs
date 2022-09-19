using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed;
    public float movementDelay;
    public float lerp;
    public float secsToNewMovement;

    public float left = -1f;
    public float right = 1f;
    public float up = 1f;
    public float down = -1f;
    public float forward = 0.25f;

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

    Vector3 Vector3Forward;
    Vector3 Vector3Left;
    Vector3 Vector3Right;
    Vector3 Vector3UpLeft;
    Vector3 Vector3UpRight;
    Vector3 Vector3DownLeft;
    Vector3 Vector3DownRight;
    

    private void Start()
    {
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
        // move forward

        SnakeHead.GetComponent<Rigidbody>().velocity = Vector3.Lerp(SnakeHead.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake1.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake1.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake2.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake2.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake3.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake3.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake4.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake4.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake5.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake5.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake6.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake6.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake7.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake7.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake8.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake8.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake9.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake9.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;
        Snake10.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake10.GetComponent<Rigidbody>().velocity, Vector3Forward, lerp) * speed;

        //SnakeHead.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward) * speed; 
        //Snake2...

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & up & right

        SnakeHead.GetComponent<Rigidbody>().velocity = Vector3.Lerp(SnakeHead.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake1.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake2.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake3.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake4.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake5.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake6.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake7.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake8.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake9.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake10.GetComponent<Rigidbody>().velocity, Vector3UpRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & down & left

        SnakeHead.GetComponent<Rigidbody>().velocity = Vector3.Lerp(SnakeHead.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake1.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake2.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake3.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake4.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake5.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake6.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake7.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake8.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake9.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake10.GetComponent<Rigidbody>().velocity, Vector3DownLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & left

        SnakeHead.GetComponent<Rigidbody>().velocity = Vector3.Lerp(SnakeHead.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake1.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake2.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake3.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake4.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake5.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake6.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake7.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake8.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake9.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake10.GetComponent<Rigidbody>().velocity, Vector3Left, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & right

        SnakeHead.GetComponent<Rigidbody>().velocity = Vector3.Lerp(SnakeHead.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake1.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake2.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake3.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake4.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake5.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake6.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake7.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake8.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake9.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake10.GetComponent<Rigidbody>().velocity, Vector3Right, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & down & right

        SnakeHead.GetComponent<Rigidbody>().velocity = Vector3.Lerp(SnakeHead.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake1.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake2.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake3.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake4.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake5.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake6.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake7.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake8.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake9.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake10.GetComponent<Rigidbody>().velocity, Vector3DownRight, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);

        yield return new WaitForSeconds(secsToNewMovement);

        // move forward & up & left

        SnakeHead.GetComponent<Rigidbody>().velocity = Vector3.Lerp(SnakeHead.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake1.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake1.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake2.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake2.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake3.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake3.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake4.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake4.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake5.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake5.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake6.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake6.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake7.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake7.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake8.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake8.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake9.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake9.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);
        Snake10.GetComponent<Rigidbody>().velocity = Vector3.Lerp(Snake10.GetComponent<Rigidbody>().velocity, Vector3UpLeft, lerp) * speed;
        yield return new WaitForSeconds(movementDelay);

        // cobra pattern;
        // - stop moving forward
        // head pointing outward

    }
}
