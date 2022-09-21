using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDiscReplacerMovement : MonoBehaviour
{
    public float powerupMovementTimer = 2f;
    private float powerupMovementTimerReset;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        powerupMovementTimerReset = powerupMovementTimer;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        powerupMovementTimer -= Time.deltaTime;
        if (powerupMovementTimer <= 0)
        {
            _rb.AddForce(0,0,2);
            //Reset streak if timer is below 0
            // enemyStreak = 0;
        }
    }
}
