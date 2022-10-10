using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource discoDiscMusic;

    public GameObject fireworksStart1;
    public GameObject fireworksStart2;
    public GameObject fireworksStart3;
    public GameObject fireworksStart4;
    public GameObject fireworksStart5;
    public GameObject fireworksStart6;

    void Start()
    {
        StartCoroutine(StartMusic());
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(6.4f);
        discoDiscMusic.Play();
        yield return new WaitForSeconds(0.2f);
        fireworksStart1.SetActive(true);
        Destroy(fireworksStart1, 3f);
        yield return new WaitForSeconds(0.2f);
        fireworksStart2.SetActive(true);
        Destroy(fireworksStart2, 3f);
        yield return new WaitForSeconds(0.2f);
        fireworksStart3.SetActive(true);
        Destroy(fireworksStart3, 3f);
        yield return new WaitForSeconds(0.2f);
        fireworksStart4.SetActive(true);
        Destroy(fireworksStart4, 3f);
        yield return new WaitForSeconds(0.2f);
        fireworksStart5.SetActive(true);
        Destroy(fireworksStart5, 3f);
        fireworksStart6.SetActive(true);
        Destroy(fireworksStart6, 3f);

    }
}
