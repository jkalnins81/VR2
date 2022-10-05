using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BaloonKillerRight : MonoBehaviour
{
    public GameObject baloon;

    public GameObject part1;
    public GameObject part2;
    public GameObject part3;

    public GameObject baloonExplosionParticles;



    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Disc"))
        {
            
            GameManager.Instance.PlaySound(GameManager.Instance.audioClips[14], 0.8f);

            BaloonChecker baloonChecker = GetComponentInParent<BaloonChecker>();

            baloonChecker.RightBaloon = true;
 
            
            GameObject ballonParticles = Instantiate(baloonExplosionParticles, transform.position, quaternion.identity);
            Destroy(ballonParticles,1.2f);
            
            if (baloonChecker.LefttBaloon && baloonChecker.MiddleBaloon && baloonChecker.RightBaloon)
            {
                Destroy(ballonParticles);
    
                Destroy(baloon);
                GetComponentInParent<AIHealthClown>().AIDie();
            }
            
            StartCoroutine(DestroyParts(ballonParticles));

            GetComponent<MeshRenderer>().enabled = false;
            
            part1.GetComponent<ClownDestroyParts>().DestroyMe();
            part2.GetComponent<ClownDestroyParts>().DestroyMe();
            part3.GetComponent<ClownDestroyParts>().DestroyMe();
            
            part1.transform.parent = null;
            part2.transform.parent = null;
            part3.transform.parent = null;
            
            part1.GetComponent<Rigidbody>().isKinematic = false;
            part2.GetComponent<Rigidbody>().isKinematic = false;
            part3.GetComponent<Rigidbody>().isKinematic = false;
            
            part1.GetComponent<Rigidbody>().useGravity = true;
            part2.GetComponent<Rigidbody>().useGravity = true;
            part3.GetComponent<Rigidbody>().useGravity = true;
            
            part1.GetComponent<Collider>().enabled = true;
            part2.GetComponent<Collider>().enabled = true;
            part3.GetComponent<Collider>().enabled = true;
            
            StartCoroutine(EnableBoxColliders());
            
            
        }
    }


    IEnumerator EnableBoxColliders()
    {
        yield return new WaitForSeconds(0.2f);

   
    }

    IEnumerator DestroyParts(GameObject particles)
    {
        yield return new WaitForSeconds(3f);
        // Destroy(particles);
        Destroy(part1);
        Destroy(part2);
        Destroy(part3);
        Destroy(baloon);


    }
}
