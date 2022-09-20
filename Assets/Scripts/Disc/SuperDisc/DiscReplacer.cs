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

        FindActiveDiscs();

        for (int i = 0; i < allActiveDiscs.Length; i++)
        {
            int numberOBJ = allActiveDiscs.Length;

            GameObject instantiatedSuperDisc = Instantiate(superDisc, allActiveDiscs[i].transform.position, Quaternion.identity);
            instantiatedSuperDisc.GetComponent<Rigidbody>().AddForce(Vector3.down * 100, ForceMode.Impulse);
            instantiatedSuperDisc.tag = "Disc";

            Debug.Log(numberOBJ);

            //Destroy old active discs
            if (i == numberOBJ - 1)
            {
                for (int j = 0; j < numberOBJ; j++)
                {
                    Destroy(allActiveDiscs[j].gameObject);
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
