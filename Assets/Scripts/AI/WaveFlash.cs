using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFlash : MonoBehaviour
{
    GameObject floorPrefab;
    GameObject floorPrefab1;
    GameObject floorPrefab2;
    GameObject floorPrefab3;
    GameObject floorPrefab4;
    GameObject floorPrefab5;
    GameObject floorPrefab6;
    GameObject floorPrefab7;
    GameObject floorPrefab8;
    GameObject floorPrefab9;
    GameObject floorPrefab10;
    GameObject floorPrefab11;
    GameObject floorPrefab12;
    GameObject floorPrefab13;
    GameObject floorPrefab14;
    GameObject floorPrefab15;
    GameObject floorPrefab16;
    GameObject floorPrefab17;

    [SerializeField] public Material floorMat;
    [SerializeField] public Material floorMatFlash;
    //[SerializeField] public AudioSource waveFlashSFX;

    [SerializeField] public GameObject enemyWaveSpawner;

    public void StartWaveFlash()
    {
        floorPrefab = GameObject.Find("0");
        floorPrefab1 = GameObject.Find("1");
        floorPrefab2 = GameObject.Find("2");
        floorPrefab3 = GameObject.Find("3");
        floorPrefab4 = GameObject.Find("4");
        floorPrefab5 = GameObject.Find("5");
        floorPrefab6 = GameObject.Find("6");
        floorPrefab7 = GameObject.Find("7");
        floorPrefab8 = GameObject.Find("8");
        floorPrefab9 = GameObject.Find("9");
        floorPrefab10 = GameObject.Find("10");
        floorPrefab11 = GameObject.Find("11");
        floorPrefab12 = GameObject.Find("12");
        floorPrefab13 = GameObject.Find("13");
        floorPrefab14 = GameObject.Find("14");
        floorPrefab15 = GameObject.Find("15");
        floorPrefab16 = GameObject.Find("16");
        floorPrefab17 = GameObject.Find("17");



        StartCoroutine(WaveFlashing());
    }

    public IEnumerator WaveFlashing()
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

        floorPrefab.GetComponent<Renderer>().material = floorMat;
        floorPrefab12.GetComponent<Renderer>().material = floorMat;
        floorPrefab1.GetComponent<Renderer>().material = floorMat;
        floorPrefab11.GetComponent<Renderer>().material = floorMat;
        floorPrefab2.GetComponent<Renderer>().material = floorMat;
        floorPrefab15.GetComponent<Renderer>().material = floorMat;
        floorPrefab3.GetComponent<Renderer>().material = floorMat;
        floorPrefab16.GetComponent<Renderer>().material = floorMat;
        floorPrefab5.GetComponent<Renderer>().material = floorMat;
        floorPrefab17.GetComponent<Renderer>().material = floorMat;
        floorPrefab6.GetComponent<Renderer>().material = floorMat;
        floorPrefab14.GetComponent<Renderer>().material = floorMat;
        floorPrefab7.GetComponent<Renderer>().material = floorMat;
        floorPrefab13.GetComponent<Renderer>().material = floorMat;
        floorPrefab8.GetComponent<Renderer>().material = floorMat;
        floorPrefab10.GetComponent<Renderer>().material = floorMat;
        floorPrefab4.GetComponent<Renderer>().material = floorMat;
        floorPrefab9.GetComponent<Renderer>().material = floorMat;



        //waveFlashSFX.Play();
    }
}
