using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;


public class DiscPillar : MonoBehaviour
{

    [SerializeField] private GameObject[] pillars;
    private int currentRandomPillar; 
    [SerializeField] private GameObject disc;



    public bool spawnNewDiscBool = false;

    private void Start()
    {
        SpawnNewDisc();
    }

    public void SpawnNewDiscDelay(float delay)
    {
        Invoke("SpawnNewDisc", delay);
        spawnNewDiscBool = true;
    }
    public void SpawnNewDisc()
    {
        Debug.Log("Spawn new disc");
        currentRandomPillar = (UnityEngine.Random.Range(0, pillars.Length));
        spawnNewDiscBool = false;
        pillars[currentRandomPillar].SetActive(true);
        Vector3 yOffset = new Vector3(0, 0.6f, 0) + pillars[currentRandomPillar].transform.position;
        Instantiate(disc, yOffset, quaternion.identity);
    }

    public void DeActivatePillar()
    {
        pillars[currentRandomPillar].SetActive(false);
    }
    
    
    
}
