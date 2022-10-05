using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BaloonKillerMiddle : MonoBehaviour
{
    public GameObject baloon;
    public GameObject baloonExplosionParticles;



    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Disc"))
        {
            
            GameManager.Instance.PlaySound(GameManager.Instance.audioClips[14], 0.8f);

            BaloonChecker baloonChecker = GetComponentInParent<BaloonChecker>();

            baloonChecker.MiddleBaloon = true;
 
            
            GameObject ballonParticles = Instantiate(baloonExplosionParticles, transform.position, quaternion.identity);
            Destroy(ballonParticles,1.2f);
            
            if (baloonChecker.LefttBaloon && baloonChecker.MiddleBaloon && baloonChecker.RightBaloon)
            {
                Destroy(ballonParticles);
                Destroy(baloon);
                GetComponentInParent<AIHealthClown>().AIDie();
            }
            
            // StartCoroutine(DestroyParticles(ballonParticles));

            GetComponent<MeshRenderer>().enabled = false;

        }
    }

    

    IEnumerator DestroyParticles(GameObject particles)
    {
        yield return new WaitForSeconds(1f);
        Destroy(particles);


    }
}
