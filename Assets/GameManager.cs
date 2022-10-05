using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{



    [SerializeField] private TextMeshPro enemyStreakCounter;
    public int enemyStreak = 0;
    public float enemyStreakTime = 3;
    private float enemyStreakTimereset;

    public int playerHealth = 100;
    private int playerRestartHealth;
    [SerializeField] private TextMeshPro currentHealthDisplay;

    public bool replacingDiscs;
    
    [SerializeField] private TextMeshPro scoreText;
    public GameObject scoreImage;
    private Image scoreImage2;
    public int score;

    public GameObject streakDisplayGO;
    public GameObject streakImage;
    private Image streakImage2;
    
    public GameObject currentHealthDisplayGO;
    public GameObject healthImage;
    private Image healthImage2;
    
    public GameObject gameOverDisplayGO;

    private static GameManager _instance;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private Color colorReset;
    private bool greenlight = false;

    private WaveFinishedSounds _waveFinishedSounds;

    public CameraManager cameraManager;
    
    private void Start()
    {
        
        playerRestartHealth = playerHealth;

        currentHealthDisplay.text = playerRestartHealth.ToString();
        
        _waveFinishedSounds = FindObjectOfType<WaveFinishedSounds>();
        colorReset = new Color(202, 205, 255, 255);
        
        healthImage2 = healthImage.GetComponent<Image>();
        streakImage2 = streakImage.GetComponent<Image>();
        scoreImage2 = scoreImage.GetComponent<Image>();
        
        audioSource = GetComponent<AudioSource>();
        scoreText.text = "0";
        
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

    private static GameManager instance = null; // the private static singleton instance variable
    public static GameManager Instance { get { return instance; } } // public getter property, anyone can access it!

    private void Awake()
    {
        if (instance == null)
        {
            // if the singleton instance has not yet been initialized
            instance = this;
        }
        else
        {
            // the singleton instance has already been initialized
            if (instance != this)
            {
                // if this instance of GameManager is not the same as the initialized singleton instance, it is a second instance, so it must be destroyed!
                Destroy(gameObject); // watch out, this can cause trouble!
            }
        }
    }


    //Streak Visual
    public void UpdateScore(int scoreValue)
    {
        int tmpScoreAdd = score += scoreValue;
        StartCoroutine(TextColorFlash(scoreText, scoreImage2));
        scoreText.text = tmpScoreAdd.ToString();
    }

    //Streak Visual

    public void UpdateVisualKillStreak()
    {
        enemyStreakCounter.text = enemyStreak.ToString();
        StartCoroutine(StreakColorFlashCyan(enemyStreakCounter, streakImage2));
        enemyStreakTime = enemyStreakTimereset;
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if(!greenlight) StartCoroutine(HealthColorFlashRed(currentHealthDisplay, healthImage2));
    }
    public void GiveHealth(int health)
    {
        playerHealth += health;
        StartCoroutine(HealthColorFlashGreen(currentHealthDisplay, healthImage2));
    }

    public void UpdateCurrentHealth()
    {
        currentHealthDisplay.text = playerHealth.ToString();
        
        if(playerHealth == 0)
        {
            _waveFinishedSounds.PlaygameOverSound();
            streakDisplayGO.SetActive(false);
            currentHealthDisplayGO.SetActive(false);
            gameOverDisplayGO.SetActive(true);
            StartCoroutine(RestartSceneDelay());
            Time.timeScale = 0;
        }
    }

    // public void Restart()
    // {
    //     Time.timeScale = 1;
    //     gameOverDisplayGO.SetActive(false);
    //     currentHealthDisplayGO.SetActive(true);
    //     streakDisplayGO.SetActive(true);
    //     SceneManager.LoadScene("DiscoDisc");
    //     playerHealth = 100;
    //     UpdateCurrentHealth();
    //
    // }
    

    IEnumerator RestartSceneDelay()
    {
        yield return new WaitForSecondsRealtime(10f);
        Time.timeScale = 1;
        cameraManager.FadeOut();
        yield return new WaitForSeconds(6f);
        gameOverDisplayGO.SetActive(false);
        currentHealthDisplayGO.SetActive(true);
        streakDisplayGO.SetActive(true);
        playerHealth = playerRestartHealth;
        score = 0;
        SceneManager.LoadScene("Rikard2");
    }

    // public void Quit()
    // {
    //     UnityEditor.EditorApplication.isPlaying = false;
    //     // Replace with "Application.Quit();" if built
    // }

    public void PlaySound(AudioClip audioClip, float volume)
    {
        audioSource.PlayOneShot(audioClip, volume);
    }
    
    
    //Text Color flashes
    
    
    IEnumerator TextColorFlash(TextMeshPro text, Image image)
    {
        text.color = new Color(227, 35, 0, 255);
        image.color = new Color(227, 35, 0, 255);
        yield return new WaitForSeconds(0.2f);
        text.color = colorReset;
        image.color = colorReset;
 
    }
    
    IEnumerator StreakColorFlashCyan(TextMeshPro text, Image image)
    {
        text.color = Color.cyan;
        image.color = Color.cyan;
        yield return new WaitForSeconds(0.2f);
        text.color = colorReset;;
        image.color = colorReset;
 
    }
    
    IEnumerator HealthColorFlashRed(TextMeshPro text, Image image)
    {
        text.color = Color.red;
        image.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        text.color = colorReset;;
        image.color = colorReset;
 
    }
    
    IEnumerator HealthColorFlashGreen(TextMeshPro text, Image image)
    {
        greenlight = true;
        text.color = Color.green;
        image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        text.color = colorReset;
        image.color = colorReset;
        yield return new WaitForSeconds(0.1f);
        text.color = Color.green;
        image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        text.color = colorReset;
        image.color = colorReset;
        yield return new WaitForSeconds(0.1f);
        text.color = Color.green;
        image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        text.color = colorReset;
        image.color = colorReset;
        yield return new WaitForSeconds(0.1f);
        text.color = Color.green;
        image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        text.color = colorReset;
        image.color = colorReset;
        yield return new WaitForSeconds(0.1f);
        text.color = Color.green;
        image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        text.color = colorReset;
        image.color = colorReset;
        yield return new WaitForSeconds(0.1f);
        text.color = Color.green;
        image.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        text.color = colorReset;
        image.color = colorReset;
        yield return new WaitForSeconds(0.1f);
        text.color = Color.green;
        image.color = Color.green;
        yield return new WaitForSeconds(1.5f);
        text.color = colorReset;
        image.color = colorReset;
        greenlight = false;

    }

    

}
