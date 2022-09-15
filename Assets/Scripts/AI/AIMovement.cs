
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    public float changeDirectionSpeed;
    private int randomNumber;

    // AI moves slowly && smoothly towards the player over time

    private void Start()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;

        StartRandomAIPattern();
    }

    void StartRandomAIPattern()
    {
        randomNumber = Random.Range(1, 5); // random number between 1 & 4 (5 is exlusive!)

        if (randomNumber == 1)
        {
            StartCoroutine(LeftRightUpDown());
        }

        if (randomNumber == 2)
        {
            StartCoroutine(LeftRightDownUp());
        }

        if (randomNumber == 3)
        {
            StartCoroutine(RightLeftUpDown());
        }

        if (randomNumber == 4)
        {
            StartCoroutine(RightLeftDownUp());
        }
    }

    IEnumerator LeftRightUpDown()
    {
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1,0,1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1,0,1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,1,1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // forward

        StartRandomAIPattern();


    }

    IEnumerator LeftRightDownUp()
    {
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // forward

        StartRandomAIPattern();
    }

    IEnumerator RightLeftUpDown()
    {
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // forward

        StartRandomAIPattern();
    }

    IEnumerator RightLeftDownUp()
    {
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 1) * speed; // left & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 1) * speed; // right & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 1) * speed; // up & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 1) * speed; // down & forward
        yield return new WaitForSeconds(changeDirectionSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * speed; // forward

        StartRandomAIPattern();
    }
}
