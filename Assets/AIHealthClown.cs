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

    [SerializeField] private Rigidbody _clownRB;
    [SerializeField] private Collider _clownCollider;

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

            
            //Give Score
            // AIDie();
            
            BlinkClown();
        }

        if (other.CompareTag("FrontWall"))
        {
 
            GameObject particles = Instantiate(AIExplosion, transform.position, Quaternion.identity);
            Destroy(particles,1);
            // GameManager.Instance.UpdateScore(-500);
            AIDie();
        }
    }

    public void AIDie()
    {
        if (_baloonChecker.LefttBaloon && _baloonChecker.MiddleBaloon && _baloonChecker.RightBaloon)
        {
            _clownCollider.enabled = true;
            _clownRB.isKinematic = false;
            _clownRB.useGravity = true;

            GameManager.Instance.UpdateScore(scoreWhenKill);

            GameObject particles = Instantiate(AIExplosion, transform.position, Quaternion.identity);
            
            GameManager.Instance.PlaySound(GameManager.Instance.audioClips[13], 1.2f);
            
            StartCoroutine(DestroyAiDelay());
  
        }

    }

    IEnumerator DestroyAiDelay()
    {
        yield return new WaitForSeconds(3f);
        GameObject particles = Instantiate(AIExplosion, _clownRB.transform.position, Quaternion.identity);
        particles.transform.parent = null;
        Destroy(particles, 1.2f);
        gameObject.SetActive(false);
        GameManager.Instance.PlaySound(GameManager.Instance.audioClips[15], 1.2f);
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
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