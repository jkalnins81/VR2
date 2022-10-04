using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    float timer;
    public float firingRateInSeconds;
    public float firingSpeed = 50f;

    public GameObject shootHolder;

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
                laser.transform.position = shootHolder.transform.position;
                laser.transform.rotation = Quaternion.identity;
                laser.SetActive(true);
                laser.GetComponent<Rigidbody>().velocity = Vector3.forward * firingSpeed;
            }
                //Instantiate(laserPrefab, transform.position, Quaternion.identity);
                timer = 0;
        }
    }
}
