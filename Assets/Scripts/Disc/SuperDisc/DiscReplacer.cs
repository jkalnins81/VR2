using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscReplacer : MonoBehaviour
{
    private GameObject[] allActiveDiscs;
    private Vector3[] allActiveDiscsPos;
    [SerializeField] private GameObject superDisc;

    public void DiscChanger()
    {
        StartCoroutine(ReplaceAllDiscs());

    }

    public IEnumerator ReplaceAllDiscs()
    {
        yield return new WaitForSeconds(0.25f);
        
        FindActiveDiscs();

        for (int i = 0; i < allActiveDiscs.Length; i++)
        {
            int numberOBJ = allActiveDiscs.Length;

            GameObject instantiatedSuperDisc = Instantiate(superDisc, allActiveDiscs[i].transform.position, Quaternion.identity);
            instantiatedSuperDisc.GetComponent<Rigidbody>().AddForce(allActiveDiscs[i].GetComponent<Rigidbody>().velocity * 10f, ForceMode.Impulse);
            instantiatedSuperDisc.tag = "Disc";

            //Destroy old active discs
            if (i == numberOBJ - 1)
            {
                for (int j = 0; j < numberOBJ; j++)
                {
                    Destroy(allActiveDiscs[j].gameObject);
                    GameManager.Instance.replacingDiscs = false;
                    // ClearDiscArray();
                }
            }
        }
    }
    

    void ClearDiscArray()
    {
        for ( int i = 0; i < allActiveDiscs.Length; i++)
        {
            allActiveDiscs[i] = null;
        }
    }

    void FindActiveDiscs()
    {
        allActiveDiscs = GameObject.FindGameObjectsWithTag("Disc");
    }
    
}
