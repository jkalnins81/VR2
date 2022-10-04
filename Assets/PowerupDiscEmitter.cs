using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDiscEmitter : MonoBehaviour
{
    public float powerupMovementTimer = 2f;
    private float powerupMovementTimerReset;

    [SerializeField] private float radiusBomb = 2f;

    [SerializeField] private GameObject particleSystemDestroyBomb;
    [SerializeField] private GameObject particleSystemDestroyEnemy;

    public float destroyMyselfTimer = 10.0f;
    
    private Rigidbody _rb;

    
    [SerializeField] private GameObject bonusDisc;


   
    
    
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
            _rb.AddForce(0, 0, 2);
            //Reset streak if timer is below 0
            // enemyStreak = 0;
        }
    }

    IEnumerator DestroyPowerupTimer()
    {
        yield return new WaitForSeconds(destroyMyselfTimer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Disc")
        {
            if (other.tag == "Disc")
            {
                StartCoroutine(DestroyDelayMyself());
                GameManager.Instance.UpdateScore(50);
                SpawnBonusDisc(gameObject.transform.position);
                SpawnBonusDisc(gameObject.transform.position);
                SpawnBonusDisc(gameObject.transform.position);
                GetComponent<Collider>().enabled = false; 
            }
        }
    }
    

    IEnumerator DestroyDelayMyself()
    {
        GameManager.Instance.PlaySound(GameManager.Instance.audioClips[1], 1f);
        yield return new WaitForSeconds(0.1f);
        DestroyEffects();
    }

    public void DestroyEffects()
    {
        GameObject particles = Instantiate(particleSystemDestroyBomb, transform.position, Quaternion.identity);
        particles.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        particles.transform.parent = null;
        Destroy(particles, 0.5f);
        Destroy(gameObject);
    }
    
    public void SpawnBonusDisc(Vector3 spawnPos)
    {
        
        // Random Vector
        float randomX = UnityEngine.Random.Range(-1, 1);
        float randomY = UnityEngine.Random.Range(-1, 1);
        float randomZ = UnityEngine.Random.Range(-1, 1);
        Vector3 randomDir = new Vector3(randomX, randomY, randomZ);
        
        GameObject spawnBonusDisc = Instantiate(bonusDisc, spawnPos + randomDir, Quaternion.identity);
        
        spawnBonusDisc.transform.parent = null;
        // spawnBonusDisc.SetActive(false);
        Rigidbody spawnedDiscRb = spawnBonusDisc.GetComponent<Rigidbody>();

  

        //Add Exception if direction is zeroed out 
        if (randomDir == Vector3.zero) randomDir = new Vector3(1, 0, 1);
        
        //Wait to add force and enable obj in order to avoid the disc to collide 
        float randomBonusDiscForceMultiplier = UnityEngine.Random.Range(120f, 200f);
        spawnedDiscRb.AddForce(randomDir * randomBonusDiscForceMultiplier, ForceMode.Impulse);
    }



}