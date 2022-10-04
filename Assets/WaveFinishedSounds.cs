using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WaveFinishedSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    
    public AudioClip[] audioClipsKillStreak;

    public AudioClip discoStart;
    public AudioClip gameOverVoice;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // audioSource.PlayOneShot(discoStart, 2);
    }

    public void PlayWaveSound()
    {  
        audioSource.Stop();
       int randClip = UnityEngine.Random.Range(0, audioClips.Length);
       audioSource.PlayOneShot(audioClips[randClip], 1.8f);
    }
    
    public void PlayKillStreakSound(int streakNumber)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipsKillStreak[streakNumber], 1.8f);
    }

    public void PlaygameOverSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverVoice, 0.5f);
    }
}
