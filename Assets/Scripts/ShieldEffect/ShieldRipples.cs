using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRipples : MonoBehaviour
{
    public GameObject ripplesVFX;

    private Material mat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AILaser"))
        {
            var ripples = Instantiate(ripplesVFX, transform) as GameObject;
            var psr = ripples.transform.GetChild(0).GetComponent<ParticleSystemRenderer>();
            mat = psr.material;
            
            mat.SetVector("_SphereCenter", collision.contacts[0].point);

            // this is the same as a bulletHole?

            Destroy(ripples, 2);
        }
    }
}
