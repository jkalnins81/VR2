
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    public float horizontalSpeed;

    // AI moves slowly && smoothly towards the player over time

    private void Start()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
        StartCoroutine(BobUpDown());
    }

    IEnumerator BobUpDown()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1,0,1) * speed; // left & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1,0,1) * speed; // right & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,1,1) * speed; // up & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // forward





    }

    // AI moves up/down && left/right towards the player over time
}
