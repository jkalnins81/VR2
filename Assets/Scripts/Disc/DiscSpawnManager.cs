using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSpawnManager : MonoBehaviour
{
   [SerializeField] private GameObject discPillarLeft;
   private Vector3 discPillarLeftPos;
   [SerializeField] private GameObject discPillarRight;
   private Vector3 discPillarRightPos;

   [SerializeField] private GameObject discLeft;
   [SerializeField] private GameObject discRight;
   
   private Vector3 yOffset = new Vector3(0,0.8f,0);
   

   private void Start()
   {
      discPillarLeftPos = discPillarLeft.gameObject.transform.position;
      discPillarRightPos = discPillarRight.gameObject.transform.position;
   }

   public void SpawnDiscLeft()
   {
      StartCoroutine(SpawnDelayLeft());
   }
   
   IEnumerator SpawnDelayLeft()
   {
      yield return new WaitForSeconds (0.25f);
      Instantiate(discLeft, discPillarLeftPos + yOffset, Quaternion.identity);
   }

   
   public void SpawnDiscRight()
   {
      StartCoroutine(SpawnDelayRight());
   }

   IEnumerator SpawnDelayRight()
   {
      yield return new WaitForSeconds (0.25f);
      Instantiate(discRight, discPillarRightPos + yOffset, Quaternion.identity);
   }
   
}
