using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTakeDamage : MonoBehaviour
{
    public GameObject snakeHealthGO;
    public GameObject AIExplosion;

    public GameObject snakeParent;
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

    [SerializeField] public GameObject cube004;
    [SerializeField] public Material snakeMaterial;
    [SerializeField] public Material snakeFlashMaterial;

    private void OnTriggerEnter(Collider other)
    {
        
        
           if (other.CompareTag("Disc"))
            {
                
                GameManager.Instance.PlaySound(GameManager.Instance.audioClips[12], 1);
                
                    if(this.gameObject.CompareTag("SnakeHead"))
                    {
                        snakeHealthGO.GetComponent<SnakeHealth>().snakeHealth -= 10;

                        if (snakeHealthGO.GetComponent<SnakeHealth>().snakeHealth <= 0)
                        {
                           GameObject particles =  Instantiate(AIExplosion, transform.position, Quaternion.identity);
                           Destroy(particles, 1f);
                            SnakeDie();
                        }

                        StartCoroutine(SnakeFlash());
                    }

                    if(!this.gameObject.CompareTag("SnakeHead"))
                    {
                        snakeHealthGO.GetComponent<SnakeHealth>().snakeHealth -= 2.5f;

                        if (snakeHealthGO.GetComponent<SnakeHealth>().snakeHealth <= 0)
                        {
                            GameObject particles2 =  Instantiate(AIExplosion, transform.position, Quaternion.identity);
                            Destroy(particles2, 1f);
                            SnakeDie();
                        }

                        StartCoroutine(SnakeFlash());
                    }

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("SnakeHead"))
                    //{
                        
                    //}

                    //if(SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake1"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake1);
                    //    Destroy(snake2);
                    //    Destroy(snake3);
                    //    Destroy(snake4);
                    //    Destroy(snake5);
                    //    Destroy(snake6);
                    //    Destroy(snake7);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake2"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake2);
                    //    Destroy(snake3);
                    //    Destroy(snake4);
                    //    Destroy(snake5);
                    //    Destroy(snake6);
                    //    Destroy(snake7);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake3"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake3);
                    //    Destroy(snake4);
                    //    Destroy(snake5);
                    //    Destroy(snake6);
                    //    Destroy(snake7);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake4"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake4);
                    //    Destroy(snake5);
                    //    Destroy(snake6);
                    //    Destroy(snake7);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake5"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake5);
                    //    Destroy(snake6);
                    //    Destroy(snake7);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake6"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake6);
                    //    Destroy(snake7);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake7"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake7);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake8"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake8);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake9"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake9);
                    //    Destroy(snake10);
                    //}

                    //if (SnakeHealthPoints <= 0 && this.gameObject.CompareTag("Snake10"))
                    //{
                    //    Instantiate(AIExplosion, transform.position, Quaternion.identity);
                    //    Destroy(snake10);
                    //}
           }

            if (other.CompareTag("FrontWall"))
            {
                GameObject particles3 =  Instantiate(AIExplosion, transform.position, Quaternion.identity);
                Destroy(particles3, 1f);
                SnakeDie();
            }
    }

    IEnumerator SnakeFlash()
    {
        cube004.GetComponent<Renderer>().material = snakeFlashMaterial;
        yield return new WaitForSeconds(0.1f);
        cube004.GetComponent<Renderer>().material = snakeMaterial;
        yield return new WaitForSeconds(0.1f);
        cube004.GetComponent<Renderer>().material = snakeFlashMaterial;
        yield return new WaitForSeconds(0.1f);
        cube004.GetComponent<Renderer>().material = snakeMaterial;
    }

    void SnakeDie()
    {
        Destroy(snakeParent);
        //Destroy(transform.parent.gameObject);
    }
}
