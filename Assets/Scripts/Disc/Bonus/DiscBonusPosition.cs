using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class DiscBonusPosition : MonoBehaviour
{
    private float randomBonusDiscForceMultiplier;

    [SerializeField] private BonusDiscSpawner bonusDiscSpawner;

    void Start()
    {
        bonusDiscSpawner = FindObjectOfType<BonusDiscSpawner>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AIEnemy")
        {
            GameManager.Instance.enemyStreak++;
            GameManager.Instance.UpdateVisualKillStreak();
            
            //Send position to BonusDiscInstantiator, where the new discs should emit
            Vector3 spawnPos = other.gameObject.transform.position;
            bonusDiscSpawner.BonusDiscInstantiator(spawnPos);
        }
    }
}
