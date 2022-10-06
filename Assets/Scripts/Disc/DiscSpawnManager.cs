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

   private Vector3 yOffset = new Vector3(0, 1f, 0);
   
   
   private Vector3 yOffsetParticles = new Vector3(0, 0.5f, 0);

   [SerializeField] private GameObject particleEffect;


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
      yield return new WaitForSeconds(1f);
      
      GameObject particles = Instantiate(particleEffect, discPillarLeftPos + yOffsetParticles, Quaternion.identity);
      particles.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
      particles.transform.Rotate(90, 0, 0);
      Destroy(particles, 0.2f);
      
      GameObject instantiatedDisc = Instantiate(discLeft, discPillarLeftPos + yOffset, Quaternion.identity);
      StartCoroutine(ScaleOverTime(0.25f, instantiatedDisc));
   }


   public void SpawnDiscRight()
   {
      StartCoroutine(SpawnDelayRight());
   }

   IEnumerator SpawnDelayRight()
   {
      yield return new WaitForSeconds(1f);
      
      GameObject particles = Instantiate(particleEffect, discPillarRightPos + yOffsetParticles, Quaternion.identity);
      particles.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
      particles.transform.Rotate(90, 0, 0);
      Destroy(particles, 0.2f);

      GameObject instantiatedDisc = Instantiate(discRight, discPillarRightPos + yOffset, Quaternion.identity);
      StartCoroutine(ScaleOverTime(0.25f, instantiatedDisc));
   }
   
   
   IEnumerator ScaleOverTime(float time, GameObject disc)
   {
      Vector3 orgScale = Vector3.zero;
      Vector3 destinationScale = new Vector3(0.2326897f, 0.01604757f, 0.2326897f);

      float currentTime = 0.0f;

      do
      {
         disc.transform.localScale = Vector3.Lerp(orgScale, destinationScale, currentTime / time);
         currentTime += Time.deltaTime;
         yield return null;
      } while (currentTime <= time);

   }
   
   

}
