using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class DiscBonusCalculator : MonoBehaviour
{
    public GameObject bonusDisc;
    public int streakBonusDiscNumber = 3;
    private float bonusDiscForceMultiplier = 100.0f;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AIEnemy")
        {
            Vector3 spawnPos = other.gameObject.transform.position;
            GameManager.Instance.enemyStreak++;
            GameManager.Instance.UpdateVisualScore();

            if (GameManager.Instance.enemyStreak == streakBonusDiscNumber)
            {
       
                SpawnBonusDisc(spawnPos);

            }
            
            if (GameManager.Instance.enemyStreak == 6)
            {
                SpawnBonusDisc(spawnPos);
                SpawnBonusDisc(spawnPos);
            }
            
            if (GameManager.Instance.enemyStreak == 8)
            {
                SpawnBonusDisc(spawnPos);
                SpawnBonusDisc(spawnPos);
                SpawnBonusDisc(spawnPos);
                
            }
        }
    }

    void SpawnBonusDisc(Vector3 spawnPos)
    {
        GameObject spawnBonusDisc = Instantiate(bonusDisc, spawnPos, Quaternion.identity);
        Debug.Log(spawnBonusDisc.transform.position);
        Debug.Log("BONUS DISC");
        Rigidbody spawnedDiscRb = spawnBonusDisc.GetComponent<Rigidbody>();

        float randomX = UnityEngine.Random.Range(-1, 1);
        float randomY = UnityEngine.Random.Range(-1, 1);
        float randomZ = UnityEngine.Random.Range(-1, 1);
        Vector3 randomDir = new Vector3(randomX, randomY, randomZ);

        StartCoroutine(AddForceDisc(spawnBonusDisc, randomDir));

    }

    IEnumerator AddForceDisc(GameObject spawnedDisc, Vector3 randomDir)
    {
        yield return new WaitForSeconds(0.15f);
        spawnedDisc.GetComponent<Rigidbody>().AddForce(randomDir * bonusDiscForceMultiplier, ForceMode.Impulse);

        
    }
    
    
    
}
