using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class DiscPillar : MonoBehaviour
{

    [SerializeField] private GameObject pillar;
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
        spawnNewDiscBool = false;
        Vector3 yOffset = new Vector3(0, 0.5f, 0) + pillar.transform.position;
        pillar.SetActive(true);
        Instantiate(disc, yOffset, quaternion.identity);
    }


    
    
}
