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

    private static GameManager _instance;

    private void Start()
    {
        enemyStreakTimereset = enemyStreakTime;
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
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    
    public GameObject[] activeDiscs;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateVisualScore()
    {
        enemyStreakCounter.text = enemyStreak.ToString();
        enemyStreakTime = enemyStreakTimereset;
    }
    
}
