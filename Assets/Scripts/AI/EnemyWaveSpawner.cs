using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{

    public GameObject textWaveFinished;
    public enum SpawnState {spawning, waiting, counting};
    [HideInInspector] public bool ableToSpawn;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemyObj;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    public float searchCountdown = 1f;

    public SpawnState state = SpawnState.counting;

    public GameObject waveFlashGO;

    private AudioSource audioData;

    private WaveFinishedSounds _waveFinishedSounds;

    private Fireworks _fireworks;
    
    //Doors

    [SerializeField] private OpenDoors openDoors;

    private void Start()
    {
        _fireworks = FindObjectOfType<Fireworks>();
        
        _waveFinishedSounds = FindObjectOfType<WaveFinishedSounds>();

        openDoors = FindObjectOfType<OpenDoors>();
        
        audioData = GetComponent<AudioSource>();
        
        ableToSpawn = true;

        waveCountDown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            //Debug.Log("Error, No Spawn Points Available");
        }
    }

    

    

 
    private void Update()
    {
        if (ableToSpawn)
        {
            if (state == SpawnState.waiting)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                    return;
                }
                else
                {
                    return;
                }
            }

            if (waveCountDown <= 0)
            {
                if (state != SpawnState.spawning)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }

    }

    void WaveCompleted()
    {
        state = SpawnState.counting;
        
        //Close door
        openDoors.closingDoors();
        
        waveCountDown = timeBetweenWaves;
        waveFlashGO.GetComponent<WaveFlash>().StartWaveFlash();

        if (nextWave + 1 > waves.Length - 1)
        {
            //All waves completed
            nextWave = 0;
            ableToSpawn = true;
        }
        else
        {
        nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("AIEnemy").Length <= 0)
            {
                WaveFinishedText();
                audioData.Play(5);
                return false;
            }
    }
        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        //Sound Door
        GameManager.Instance.PlaySound(GameManager.Instance.audioClips[5], 2f);
        //Open Door
        openDoors.openingDoors();
        
        state = SpawnState.spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            if (i !=2)
            {
                SpawnEnemy(_wave.enemyObj);
            }

            if (i == 2)
            {
                SpawnBoss(_wave.enemyObj);
            }

            yield return new WaitForSeconds(_wave.rate);
        }

        state = SpawnState.waiting;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    public void SpawnBoss(Transform _boss)
    {
        Transform _spBoss = spawnPoints[12];
        Instantiate(_boss, _spBoss.position, _spBoss.rotation);
    }


    
    void WaveFinishedText()
    {
        _waveFinishedSounds.PlayWaveSound();
        _fireworks.FireWorks();
        StartCoroutine(WaveTextFinished());
    }

    IEnumerator WaveTextFinished()
    {
        yield return new WaitForSeconds(0.5f);
        textWaveFinished.GetComponentInChildren<TextMeshPro>().text = ("Wave ") + nextWave.ToString() + (" Finished");
        textWaveFinished.SetActive(true);
        
        yield return new WaitForSeconds(4.5f);
        textWaveFinished.SetActive(false);
    }
    
}
