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

    private float controllerMaxSpeed = 1f;
    [SerializeField] private float forceMultiplier = 100;

    public XRGrabInteractable thisXRGrabInteractable;

    public DiscPillar DiscPillar;

    public Quaternion throwAngle;
    private float time = 3.0f;

    public float destroyTinmeAfterThrow = 5f;

    public GameObject particleSystemDestroy;

    //Self Destruct
    public float discSelfDestructTimer = 3.0f;
    
    //Spawn Manager

    private DiscSpawnManager _discSpawnManager;
    

    private void Start()

    {
        _discSpawnManager = FindObjectOfType<DiscSpawnManager>();
        
        GetComponent<Renderer>().material.SetColor("color", Color.black);
        discRB = GetComponent<Rigidbody>();
        controllerVelocity = FindObjectOfType<ControllerVelocity>();

        // colliders = GetComponentsInChildren<Collider>();
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
        
        //Self destruct
        // if (colliders[0].enabled == false)
        // {
        //     discSelfDestructTimer -= Time.deltaTime;
        //
        //     if (discSelfDestructTimer <= 0)
        //     {
        //         GameObject particles = Instantiate(particleSystemDestroy, transform.position, quaternion.identity);
        //         Destroy(particles, 1f);
        //         Destroy(gameObject);
        //     }
        // }
    }


    public void ReleaseVelocity()
    {
        float handSpeed = controllerVelocity.rightHandRB.velocity.magnitude;
        //Spawn new disc pillar on release
        // DiscPillar.DeActivatePillar();
        // DiscPillar.spawnNewDiscBool = true;
        // DiscPillar.SpawnNewDiscDelay(1f);
        
        //Scale Disc
        StartCoroutine(ScaleOverTime(2f));
        
        //Destroy after X seconds
        StartCoroutine(DestroyDiscAfterThrow());

        if (handSpeed >= controllerMaxSpeed)
        {
            //Cap the max throw speed vel
            //Start coroutine and add force after the XR scripts adds it's own throw velocity 
            StartCoroutine(AddForceAfterThrow());
        }
        else
        {
            // if arm movement is slow, output this 
            // float discPercentage = handSpeed / discMaxSpeed;
            // Debug.Log(discPercentage);
            throwAngle = gameObject.transform.rotation;
            thisXRGrabInteractable.throwVelocityScale = 200f;
            discRB.AddForce(discRB.velocity.normalized, ForceMode.Impulse);
        }

    }

    public void DisableDiscCollider()
    {
        //Disable collider from controller script 
        
        colliders[0].enabled = false;
        colliders[1].enabled = false;
        colliders[2].enabled = false;
    }

    public void EnabaleDiscCollider()
    {
        //Enable collider from controller script 
        gameObject.tag = "Disc";
        StartCoroutine(DiscColliderOn());
    }

    IEnumerator DiscColliderOn()
    {
        yield return new WaitForSeconds(0.10f);
        colliders[0].enabled = true;
        colliders[2].enabled = true;
        yield return new WaitForSeconds(0.20f);
        discRB.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(0.10f);
        colliders[1].enabled = true;
        
    }


    IEnumerator AddForceAfterThrow()
    {
        //Ads force to the disc once it is released and has got the velocity from the controller 
        yield return new WaitForSeconds(0.01f);
        thisXRGrabInteractable.throwVelocityScale = 2000f;
        thisXRGrabInteractable.throwAngularVelocityScale = 2f;
        discRB.AddForce(discRB.velocity.normalized * forceMultiplier, ForceMode.Impulse);
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
        // if (collision.gameObject.tag == "Disc")
        // {
        //     DestroyDiscEffects();
        // }
    }

    public void DestroyDiscEffects()
    {
        GameObject particles = Instantiate(particleSystemDestroy, transform.position, quaternion.identity);
        Destroy(particles, 1f);
        Destroy(gameObject);
    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 orgScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(0.75f, 0.1f, 0.75f);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(orgScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

    }

    public void LeftDiscSpawn()
    {
        _discSpawnManager.SpawnDiscLeft();
    }
    
    public void RightDiscSpawn()
    {
        _discSpawnManager.SpawnDiscRight();
    }
    
}
