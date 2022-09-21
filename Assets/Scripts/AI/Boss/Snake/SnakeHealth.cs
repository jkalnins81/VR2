using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    public int SnakeHealthPoints;
    public int SnakeHeadHealthPoints;
    public GameObject AIExplosion;

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
