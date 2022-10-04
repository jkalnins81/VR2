using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{

    public GameObject[] fireWorks;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip fireworksClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void FireWorks()
    {
        StartCoroutine(PlayFireworks());
    }

    IEnumerator PlayFireworks()
    {
        _audioSource.PlayOneShot(fireworksClip, 2);
        yield return new WaitForSeconds(0.5f);
        _audioSource.PlayOneShot(fireworksClip, 2);
        yield return new WaitForSeconds(0.5f);
        _audioSource.PlayOneShot(fireworksClip, 2);
        yield return new WaitForSeconds(0.5f);
        _audioSource.PlayOneShot(fireworksClip, 2);
        yield return new WaitForSeconds(0.1f);
        fireWorks[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        fireWorks[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        fireWorks[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        fireWorks[3].SetActive(true);
        yield return new WaitForSeconds(3f);
        fireWorks[0].SetActive(false);
        fireWorks[1].SetActive(false);
        fireWorks[2].SetActive(false);
        fireWorks[3].SetActive(false);
        

    }
}
