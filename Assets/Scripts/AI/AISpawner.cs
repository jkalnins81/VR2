using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject AIEnemyPrefab;
    float timer;
    public float spawnRateInSeconds;
    float randomPositionOffsetY;
    float randomPositionOffsetZ;

    private void Start()
    {
        Instantiate(AIEnemyPrefab, transform.localPosition, Quaternion.identity);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRateInSeconds)
        {
            randomPositionOffsetY = Random.Range(-2, 2);
            randomPositionOffsetZ = Random.Range(-2, 2);

            Instantiate(AIEnemyPrefab, new Vector3(transform.position.x, transform.position.y + randomPositionOffsetY, transform.position.z + randomPositionOffsetY), Quaternion.identity);
            timer = 0;
        }
    }


    // spawn one every ___ seconds

    // Spawn waves
}
