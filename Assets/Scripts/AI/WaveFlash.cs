using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFlash : MonoBehaviour
{
    [SerializeField] public GameObject floorPrefab;
    [SerializeField] public GameObject floorPrefab1;
    [SerializeField] public GameObject floorPrefab2;
    [SerializeField] public GameObject floorPrefab3;
    [SerializeField] public GameObject floorPrefab4;
    [SerializeField] public GameObject floorPrefab5;
    [SerializeField] public GameObject floorPrefab6;
    [SerializeField] public GameObject floorPrefab7;
    [SerializeField] public GameObject floorPrefab8;
    [SerializeField] public GameObject floorPrefab9;
    [SerializeField] public GameObject floorPrefab10;
    [SerializeField] public GameObject floorPrefab11;
    [SerializeField] public GameObject floorPrefab12;
    [SerializeField] public GameObject floorPrefab13;
    [SerializeField] public GameObject floorPrefab14;
    [SerializeField] public GameObject floorPrefab15;
    [SerializeField] public GameObject floorPrefab16;
    [SerializeField] public GameObject floorPrefab17;

    [SerializeField] public Material floorMat;
    [SerializeField] public Material floorMatFlash;
    //[SerializeField] public AudioSource waveFlashSFX;

    [SerializeField] public GameObject enemyWaveSpawner;


    public IEnumerator StartWaveFlash()
    {
        float timeTillNextWave = enemyWaveSpawner.GetComponent<EnemyWaveSpawner>().timeBetweenWaves;

        floorPrefab.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab12.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave/9);
        floorPrefab1.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab11.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);
        floorPrefab2.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab15.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);
        floorPrefab3.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab16.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);
        floorPrefab5.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab17.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);
        floorPrefab6.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab14.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);
        floorPrefab7.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab13.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);
        floorPrefab8.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab10.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);
        floorPrefab4.GetComponent<Renderer>().material = floorMatFlash;
        floorPrefab9.GetComponent<Renderer>().material = floorMatFlash;
        yield return new WaitForSeconds(timeTillNextWave / 9);

        //waveFlashSFX.Play();
        
    }
}
