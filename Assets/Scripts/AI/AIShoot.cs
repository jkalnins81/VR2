using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    float timer;
    public float firingRateInSeconds;

    private void Start()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= firingRateInSeconds)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
            timer = 0;
        }
    }


    // Shoot in a random place within a funnel towards the player
}
