using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    private static GameManager _instance;

    private void Start()
    {
        enemyStreakTimereset = enemyStreakTime;
        gameOverDisplayGO.SetActive(false);
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
    public void UpdateVisualKillStreak()
    {
        enemyStreakCounter.text = enemyStreak.ToString();
        enemyStreakTime = enemyStreakTimereset;
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
        }
    }

}
