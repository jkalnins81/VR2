using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDiscSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bonusDisc;

    [SerializeField] private DiscReplacer _discReplacer;

    private void Start()
    {
        _discReplacer = FindObjectOfType<DiscReplacer>();
    }

    public void BonusDiscInstantiator(Vector3 spawnPos)
    {
        
        if (GameManager.Instance.enemyStreak == 2)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
        }
        if (GameManager.Instance.enemyStreak == 3)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            _discReplacer.DiscChanger();
        }    
    }
    
    public void SpawnBonusDisc(Vector3 spawnPos)
    {
        GameObject spawnBonusDisc = Instantiate(bonusDisc, spawnPos, Quaternion.identity);
        spawnBonusDisc.SetActive(false);
        Rigidbody spawnedDiscRb = spawnBonusDisc.GetComponent<Rigidbody>();

        float randomX = UnityEngine.Random.Range(-1, 1);
        float randomY = UnityEngine.Random.Range(-1, 1);
        float randomZ = UnityEngine.Random.Range(-1, 1);
        Vector3 randomDir = new Vector3(randomX, randomY, randomZ);

        //Add Exception if direction is zeroed out 
        if (randomDir == Vector3.zero) randomDir = new Vector3(1, 0, 1);
        
        //Wait to add force and enable obj in order to avoid the disc to collide 
        StartCoroutine(AddForceDisc(spawnBonusDisc, randomDir));
    }

    IEnumerator AddForceDisc(GameObject spawnedDisc, Vector3 randomDir)
    {
        yield return new WaitForSeconds(0.15f);
        spawnedDisc.SetActive(true);
        float randomBonusDiscForceMultiplier = UnityEngine.Random.Range(80.0f, 200f);
        spawnedDisc.GetComponent<Rigidbody>().AddForce(randomDir * randomBonusDiscForceMultiplier, ForceMode.Impulse);
    }


}
