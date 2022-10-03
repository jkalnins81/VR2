using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshPro scoreText;
    public int score;

    [SerializeField] private TextMeshPro enemyStreakCounter;
    public int enemyStreak = 0;
    public float enemyStreakTime = 3;
    private float enemyStreakTimereset;

    public int playerHealth = 100;
    [SerializeField] private TextMeshPro currentHealthDisplay;

    public bool replacingDiscs;

    public GameObject streakDisplayGO;
    public GameObject currentHealthDisplayGO;
    public GameObject gameOverDisplayGO;
    public GameObject canvas;

    private static GameManager _instance;

    public AudioSource audioSource;
    public AudioClip[] audioClips;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = "0";
        
        enemyStreakTimereset = enemyStreakTime;
        gameOverDisplayGO.SetActive(false);
        canvas.SetActive(false);
    }

    private void Update()
    {
        // Streak timer
        enemyStreakTime = enemyStreakTime - Time.deltaTime;
        if (enemyStreakTime <= 0)
        {
            enemyStreakCounter.enabled = false;
            //Reset streak if timer is below 0
            enemyStreak = 0;
        }
        else
        {
            enemyStreakCounter.enabled = true;
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    //Streak Visual
    public void UpdateScore(int scoreValue)
    {
        int tmpScoreAdd = score += scoreValue;
        scoreText.text = tmpScoreAdd.ToString();
    }

    //Streak Visual
    public void UpdateVisualKillStreak()
    {
        enemyStreakCounter.text = enemyStreak.ToString();
        enemyStreakTime = enemyStreakTimereset;
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }
    public void GiveHealth(int health)
    {
        playerHealth += health;
    }

    public void UpdateCurrentHealth()
    {
        currentHealthDisplay.text = playerHealth.ToString();

        if(playerHealth <= 0)
        {
            Time.timeScale = 0;
            streakDisplayGO.SetActive(false);
            currentHealthDisplayGO.SetActive(false);
            gameOverDisplayGO.SetActive(true);
            canvas.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameOverDisplayGO.SetActive(false);
        canvas.SetActive(false);
        currentHealthDisplayGO.SetActive(true);
        streakDisplayGO.SetActive(true);
        SceneManager.LoadScene("DiscoDisc");
        playerHealth = 100;
        UpdateCurrentHealth();
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Replace with "Application.Quit();" if built
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

}
