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
    [SerializeField] public AudioSource flashSFX;

    IEnumerator StartWaveFlash()
    {
        enemyDieWallSFX.Play();
        this.gameObject.GetComponent<Renderer>().material = redGlass;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Renderer>().material = glass;
    }
}
