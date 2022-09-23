using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    //[SerializeField] private Material enemyDieWallMaterial;

    [SerializeField] private Renderer enemyDieWallRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AIEnemy") || other.CompareTag("SnakeHead") || other.CompareTag("Snake1") || other.CompareTag("Snake2") || other.CompareTag("Snake3") || other.CompareTag("Snake4") || other.CompareTag("Snake5") || other.CompareTag("Snake6") || other.CompareTag("Snake7") || other.CompareTag("Snake8") || other.CompareTag("Snake9") || other.CompareTag("Snake10"))
        {
            Debug.Log("Flash");
            StartCoroutine(StartFlash());
        }
    }

    IEnumerator StartFlash()
    {
        enemyDieWallRenderer.material.color = new Color(241f, 61f, 61f, 145f);
        Debug.Log(enemyDieWallRenderer.material.color);
        yield return new WaitForSeconds(0.5f);
        enemyDieWallRenderer.material.color = new Color(255f, 255f, 255f, 0f);
    }
}
