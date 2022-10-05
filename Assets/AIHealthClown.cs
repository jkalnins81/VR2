using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealthClown : MonoBehaviour
{
    public int AIHealthPoints;
    public GameObject AIExplosion;
    GameObject EnemyDieWall;

    public int scoreWhenKill = 5;

    private int randomSound;

    private BaloonChecker _baloonChecker;

    public Renderer _renderer;
    private Color _renderColor;

    private void Start()
    {
        _renderColor = _renderer.material.color;
        _baloonChecker = GetComponent<BaloonChecker>();
        EnemyDieWall = GameObject.Find("EnemyDieWall");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Disc"))
        {
            //Sound
            randomSound = UnityEngine.Random.Range(6, 9);
            GameManager.Instance.PlaySound(GameManager.Instance.audioClips[randomSound], 0.35f);
            // Instantiate(AIExplosion, transform.position, Quaternion.identity);
            
            //Give Score
            // AIDie();
            
            BlinkClown();
        }

        if (other.CompareTag("FrontWall"))
        {
 
            GameManager.Instance.UpdateScore(-500);
            AIDie();
        }
    }

    public void AIDie()
    {
        if (_baloonChecker.LefttBaloon && _baloonChecker.MiddleBaloon && _baloonChecker.RightBaloon)
        {
            GameManager.Instance.UpdateScore(scoreWhenKill);
            Destroy(transform.parent.gameObject);
        }

    }

    public void SendVisualStreakBomb()
    {
        GameManager.Instance.enemyStreak++;
        GameManager.Instance.UpdateVisualKillStreak();
    }

    public void BlinkClown()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _renderer.material.color = Color.cyan;
        
        yield return new WaitForSeconds(0.2f);
        _renderer.material.color = Color.black;
        yield return new WaitForSeconds(0.5f);
        _renderer.material.color = _renderColor;


    }
}