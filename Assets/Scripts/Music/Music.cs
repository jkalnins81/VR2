using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource discoDiscMusic;

    public GameObject fireworksStart;

    void Start()
    {
        StartCoroutine(StartMusic());
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(6.4f);
        discoDiscMusic.Play();
        fireworksStart.SetActive(true);
        Destroy(fireworksStart.transform.parent, 3f);
    }
}
