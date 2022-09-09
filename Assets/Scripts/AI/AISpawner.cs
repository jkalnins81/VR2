using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject AIEnemyPrefab;
    float timer;
    public float spawnRateInSeconds;

    private void Start()
    {
        Instantiate(AIEnemyPrefab, transform.localPosition, Quaternion.identity);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRateInSeconds)
        {
            Instantiate(AIEnemyPrefab, transform.position, Quaternion.identity);
            timer = 0;
        }
    }


    // spawn one every ___ seconds

    // Spawn waves
}
