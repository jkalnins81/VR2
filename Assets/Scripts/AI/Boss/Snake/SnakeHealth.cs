using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    public int SnakeHealthPoints;
    public int SnakeHeadHealthPoints;
    public GameObject AIExplosion;

    public GameObject snake1;
    public GameObject snake2;
    public GameObject snake3;
    public GameObject snake4;
    public GameObject snake5;
    public GameObject snake6;
    public GameObject snake7;
    public GameObject snake8;
    public GameObject snake9;
    public GameObject snake10;


    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.CompareTag("SnakeHead"))
        {
            if (other.CompareTag("Disc"))
            {
                SnakeHeadHealthPoints -= 1;
                // insert flashing snake function

                if(SnakeHeadHealthPoints <= 0)
                {
                    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    SnakeDie();
                }

                if(SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake1"))
                {
                    Destroy(snake1);
                    Destroy(snake2);
                    Destroy(snake3);
                    Destroy(snake4);
                    Destroy(snake5);
                    Destroy(snake6);
                    Destroy(snake7);
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake2"))
                {
                    Destroy(snake2);
                    Destroy(snake3);
                    Destroy(snake4);
                    Destroy(snake5);
                    Destroy(snake6);
                    Destroy(snake7);
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake3"))
                {
                    Destroy(snake3);
                    Destroy(snake4);
                    Destroy(snake5);
                    Destroy(snake6);
                    Destroy(snake7);
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake4"))
                {
                    Destroy(snake4);
                    Destroy(snake5);
                    Destroy(snake6);
                    Destroy(snake7);
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake5"))
                {
                    Destroy(snake5);
                    Destroy(snake6);
                    Destroy(snake7);
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake6"))
                {
                    Destroy(snake6);
                    Destroy(snake7);
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake7"))
                {
                    Destroy(snake7);
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake8"))
                {
                    Destroy(snake8);
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake9"))
                {
                    Destroy(snake9);
                    Destroy(snake10);
                }

                if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake10"))
                {
                    Destroy(snake10);
                }
            }
        }

        if (other.CompareTag("FrontWall"))
        {
            SnakeDie();
        }
    }

    void SnakeDie()
    {
        Destroy(transform.parent.gameObject);
    }
}
