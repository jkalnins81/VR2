using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiscBonusCalculator : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AIEnemy")
        {
            Debug.Log("hit");
            GameManager.Instance.enemyStreak++;
            GameManager.Instance.UpdateVisualScore();
        }
    }
    
}
