using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDiscReplacerMovement : MonoBehaviour
{
    public float powerupMovementTimer = 2f;
    private float powerupMovementTimerReset;

    [SerializeField] private GameObject particleSystemDestroy;

    private DiscReplacer _discReplacer;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        powerupMovementTimerReset = powerupMovementTimer;
        _rb = GetComponent<Rigidbody>();
        
        _discReplacer = FindObjectOfType<DiscReplacer>();

        StartCoroutine(DestroyPowerupTimer());
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

    IEnumerator DestroyPowerupTimer()
    {
        yield return new WaitForSeconds(8);
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Disc")
        {
            Destroy(gameObject);
            GameManager.Instance.replacingDiscs = true;
            _discReplacer.DiscChanger();
            DestroyEffects();
        }
    }
    
    public void DestroyEffects()
    {
        GameObject particles = Instantiate(particleSystemDestroy, transform.position, Quaternion.identity);
        Destroy(particles, 1f);
        Destroy(gameObject);
    }
    
}
