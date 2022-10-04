using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int AIHealthPoints;
    public GameObject AIExplosion;
    GameObject EnemyDieWall;

    public int scoreWhenKill = 5;

    private int randomSound;

    private void Start()
    {
        EnemyDieWall = GameObject.Find("EnemyDieWall");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc"))
        {
            //Sound
            randomSound = UnityEngine.Random.Range(6, 9);
            GameManager.Instance.PlaySound(GameManager.Instance.audioClips[randomSound], 0.35f);
            
            Instantiate(AIExplosion, transform.position, Quaternion.identity);
            
            //Give Score
            GameManager.Instance.UpdateScore(scoreWhenKill);
            AIDie();
        }

        if (other.CompareTag("FrontWall"))
        {
 
            GameManager.Instance.UpdateScore(-500);
            AIDie();
        }
    }

    public void AIDie()
    {
        Destroy(transform.parent.gameObject);
    }

    public void SendVisualStreakBomb()
    {
        GameManager.Instance.enemyStreak++;
        GameManager.Instance.UpdateVisualKillStreak();
    }
}
