using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDiscSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bonusDisc;

    [SerializeField] private DiscReplacer _discReplacer;

    private WaveFinishedSounds waveFinishedSounds;
    
    private void Start()
    {
        waveFinishedSounds = FindObjectOfType<WaveFinishedSounds>();
        
        _discReplacer = FindObjectOfType<DiscReplacer>();
    }

    public void BonusDiscInstantiator(Vector3 spawnPos)
    {
        
        if (GameManager.Instance.enemyStreak == 5)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            
            waveFinishedSounds.PlayKillStreakSound(0);
        }
        if (GameManager.Instance.enemyStreak == 10)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(1);
        }    
        
        if (GameManager.Instance.enemyStreak == 20)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(2);
     
        }   
        
        if (GameManager.Instance.enemyStreak == 30)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(3);

        }    
        
        if (GameManager.Instance.enemyStreak == 40)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(4);

        }    
        
        if (GameManager.Instance.enemyStreak == 50)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(5);

        }    
        
        if (GameManager.Instance.enemyStreak == 60)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(6);

        }    
        if (GameManager.Instance.enemyStreak == 70)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(7);

        }  
        if (GameManager.Instance.enemyStreak == 80)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(8);

        }   
        if (GameManager.Instance.enemyStreak == 90)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(9);

        }   
        if (GameManager.Instance.enemyStreak == 100)
        {
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            SpawnBonusDisc(spawnPos);
            waveFinishedSounds.PlayKillStreakSound(10);

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
        float randomBonusDiscForceMultiplier = UnityEngine.Random.Range(120f, 200f);
        spawnedDisc.GetComponent<Rigidbody>().AddForce(randomDir * randomBonusDiscForceMultiplier, ForceMode.Impulse);
    }


}
