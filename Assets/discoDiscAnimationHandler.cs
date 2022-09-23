using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class discoDiscAnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private AudioSource _audioSource;

    [SerializeField] private AudioClip _audioClip;

    private float randomPitchValue;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        randomPitchValue = UnityEngine.Random.Range(0.8f, 1.8f);
    }

    public void KnifeOutAnim()
    {
        _animator.Play("knifeOut");
    }

    public void PlaySound()
    {
        _audioSource.pitch = randomPitchValue;
        _audioSource.PlayOneShot(_audioClip, 0.5f);
    }
}
