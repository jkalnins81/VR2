using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBomb : MonoBehaviour
{
    
    
    public float powerupMovementTimer = 2f;
    private float powerupMovementTimerReset;
    
    [SerializeField] private float radiusBomb = 2f;

    [SerializeField] private GameObject particleSystemDestroy;
    

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        powerupMovementTimerReset = powerupMovementTimer;
        _rb = GetComponent<Rigidbody>();

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
            if (other.tag == "Disc")
            {
                ExplosionDamage(gameObject.transform.position, radiusBomb);
                StartCoroutine(DestroyDelayMyself());

            }
        }
    }
    
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {

            if (hitCollider.gameObject.tag == "AIEnemy")
            {
                GameObject particles = Instantiate(particleSystemDestroy, hitCollider.gameObject.transform.position, Quaternion.identity);
                Destroy(particles, 1f);
                particles.transform.parent = null;
                GameObject enemy = hitCollider.gameObject;
                Destroy(enemy.transform.parent.gameObject);
            }
        }
    }

    IEnumerator DestroyDelayMyself()
    {
        yield return new WaitForSeconds(0.1f);
        DestroyEffects();
    }
    
    public void DestroyEffects()
    {
        GameObject particles = Instantiate(particleSystemDestroy, transform.position, Quaternion.identity);
        particles.transform.parent = null;
        Destroy(particles, 2f);
        Destroy(gameObject, 1f);
    }
    

}
