using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public int delayBetweenShots;
    public GameObject laserPrefab;

    private void Start()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }


    // Shoot in a random place within a funnel towards the player
}
