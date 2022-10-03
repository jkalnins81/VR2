using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ShieldRipples : MonoBehaviour
{
    public GameObject impactEffectForceField;

    private int randomSound;

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Disc"))
        {
            //Sound
            randomSound = UnityEngine.Random.Range(3, 4);
            GameManager.Instance.PlaySound(GameManager.Instance.audioClips[randomSound], 0.15f);
            
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
            Vector3 pos = contact.point;
            GameObject forceField = Instantiate(impactEffectForceField, pos, rot) as GameObject;
            Destroy(forceField, 0.5f);
        }
    }
}
