using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int AIHealthPoints;
    public GameObject AIExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc"))
        {
            Instantiate(AIExplosion, transform.position, Quaternion.identity);
            AIDie();
        }

        if (other.CompareTag("FrontWall"))
        {
            AIDie();
        }
    }

    public void AIDie()
    {
        Destroy(transform.parent.gameObject);
    }
}
