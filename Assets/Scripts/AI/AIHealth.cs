using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int AIHealthPoints;
    public GameObject AIExplosion;
    GameObject EnemyDieWall;

    private void Start()
    {
        EnemyDieWall = GameObject.Find("EnemyDieWall");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc"))
        {
            Instantiate(AIExplosion, transform.position, Quaternion.identity);
            GameManager.Instance.UpdateScore(5);
            AIDie();
        }

        if (other.CompareTag("FrontWall"))
        {
 
            GameManager.Instance.UpdateScore(-500);
            AIDie();
        }
    }

    public void AIDie()
    {
        Destroy(transform.parent.gameObject);
    }
}
