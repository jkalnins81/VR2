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
        enemyStreakTimereset = enemyStreakTimereset;
    }

    private void Update()
    {
        enemyStreakTime--;
        if (enemyStreakTime <= 0)
        {
            enemyStreakCounter.enabled = true;
        }
        else
        {
            enemyStreakCounter.enabled = false; 
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
