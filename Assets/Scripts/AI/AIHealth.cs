using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int AIHealthPoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc"))
        {
            // instantiate explosion effect
            AIDie();
        }

        if (other.CompareTag("FrontWall"))
        {
            AIDie();
        }
    }

    void AIDie()
    {
        // explosion && visual effect
        Destroy(transform.parent.gameObject);
    }
}
