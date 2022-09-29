using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRipples : MonoBehaviour
{
    public GameObject impactEffectForceField;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Disc"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, contact.normal);
            Vector3 pos = contact.point;
            GameObject forceField = Instantiate(impactEffectForceField, pos, rot) as GameObject;
            Destroy(forceField, 0.5f);
        }
    }
}
