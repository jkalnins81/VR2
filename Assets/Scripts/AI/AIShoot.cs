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
        //Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= firingRateInSeconds)
        {
            GameObject laser = LaserObjectPool.SharedInstance.GetPooledObject();

            if (laser != null)
            {
                laser.transform.position = transform.position;
                laser.transform.rotation = Quaternion.identity;
                laser.SetActive(true);
            }
                //Instantiate(laserPrefab, transform.position, Quaternion.identity);
                timer = 0;
        }
    }
}
