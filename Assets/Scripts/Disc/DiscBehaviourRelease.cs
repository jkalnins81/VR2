using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiscBehaviourRelease : MonoBehaviour
{
    public Rigidbody discRB;
    public ControllerVelocity controllerVelocity;

    public Collider[] colliders;

    private float controllerMaxSpeed = 1.8f;
    private float forceMultiplier = 100;

    public XRGrabInteractable thisXRGrabInteractable;

    public DiscPillar DiscPillar;

    public Quaternion throwAngle;
    private float time = 3.0f;

    public float destroyTinmeAfterThrow = 5f;

    public GameObject particleSystemDestroy;

    //Self Destruct
    public float discSelfDestructTimer = 3.0f;

    private void Start()
    {
        discRB = GetComponent<Rigidbody>();
        controllerVelocity = FindObjectOfType<ControllerVelocity>();

        colliders = GetComponentsInChildren<Collider>();
        thisXRGrabInteractable = GetComponent<XRGrabInteractable>();

        DiscPillar = FindObjectOfType<DiscPillar>();

    }

    private void Update()
    {
        // if (discThrown)
        // {
        //     //discRB.MoveRotation(Quaternion.RotateTowards(discRB.rotation, Quaternion.Euler(-90, transform.rotation.y, -90), 20 * Time.deltaTime));
        //     // float speed = 1.0f;
        //     // transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.identity, Time.deltaTime * 2);
        // }
        
        //bool not working from controller script, checking colliders active or not instead
        if (colliders[0].enabled == false)
            {
                discSelfDestructTimer -= Time.deltaTime;

                if (discSelfDestructTimer <= 0)
                {

                    GameObject particles = Instantiate(particleSystemDestroy, transform.position, quaternion.identity);
                    Destroy(particles, 1f);
                    Destroy(gameObject);
                }
            }
    }


    public void ReleaseVelocity()
    {
        float handSpeed = controllerVelocity.rightHandRB.velocity.magnitude;
        //Spawn new disc pillar on release
        DiscPillar.DeActivatePillar();
        DiscPillar.spawnNewDiscBool = true;
        DiscPillar.SpawnNewDiscDelay(1f); 

        StartCoroutine(DestroyDiscAfterThrow());
        
        if(handSpeed >= controllerMaxSpeed)
        {
            Debug.Log("Using max Speed");

            //Cap the max throw speed vel
            //Start coroutine and add force after the XR scripts adds it's own throw velocity 
            StartCoroutine(AddForceAfterThrow());
        }
        else
        {
            Debug.Log("Using Low speed");
            // if arm movement is slow, output this 
            // float discPercentage = handSpeed / discMaxSpeed;
            // Debug.Log(discPercentage);
            throwAngle = gameObject.transform.rotation;
            thisXRGrabInteractable.throwVelocityScale = 1.0f;
            discRB.AddForce(discRB.velocity.normalized * 0.5f, ForceMode.Impulse);
        }

    }

    public void DisableDiscCollider()
    {
        //Disable collider from controller script 
        colliders[0].enabled = false; 
        colliders[1].enabled = false; 
    }
    
    public void EnabaleDiscCollider()
    {
        //Enable collider from controller script 
        StartCoroutine(DiscColliderOn());
    }

    IEnumerator DiscColliderOn()
    {
        yield return new WaitForSeconds(0.10f);
        colliders[0].enabled = true; 
        colliders[1].enabled = true;
        yield return new WaitForSeconds(0.20f);
        discRB.constraints = RigidbodyConstraints.None;
    }


    IEnumerator AddForceAfterThrow()
    {
        //Ads force to the disc once it is released and has got the velocity from the controller 
        
        Debug.Log(throwAngle);
        yield return new WaitForSeconds(0.01f);
        thisXRGrabInteractable.throwVelocityScale = 50f;
        thisXRGrabInteractable.throwAngularVelocityScale = 10.0f;
        discRB.AddForce(discRB.velocity.normalized  * forceMultiplier, ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);
        throwAngle = gameObject.transform.rotation;
    }

    public IEnumerator DestroyDiscAfterThrow()
    {
        yield return new WaitForSeconds(destroyTinmeAfterThrow);
        DestroyDiscEffects();

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Disc")
        {
            DestroyDiscEffects();
        }
    }
    public void DestroyDiscEffects()
    {
        GameObject particles = Instantiate(particleSystemDestroy, transform.position, quaternion.identity);
        Destroy(particles, 1f);
        Destroy(gameObject);
    }


}
