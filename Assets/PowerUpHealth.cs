using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{


    public float powerupMovementTimer = 2f;
    private float powerupMovementTimerReset;

    [SerializeField] private float radiusBomb = 2f;

    [SerializeField] private GameObject particleSystemDestroyBomb;
    [SerializeField] private GameObject particleSystemDestroyEnemy;

    public float destroyMyselfTimer = 10.0f;
    




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
                GameManager.Instance.GiveHealth(40);

                GameManager.Instance.PlaySound(GameManager.Instance.audioClips[0], 1f);

                GameManager.Instance.UpdateCurrentHealth();

                StartCoroutine(DestroyDelayMyself());

            }
        }
    }

    IEnumerator DestroyDelayMyself()
    {

        yield return new WaitForSeconds(0.1f);
        DestroyEffects2();
    }

    private void DestroyEffects2()
    {

        GameObject particles = Instantiate(particleSystemDestroyBomb, transform.position, Quaternion.identity);
        particles.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        particles.transform.parent = null;
        Destroy(particles, 0.5f);
        Destroy(gameObject);
    }
}
    
