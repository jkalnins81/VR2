using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FrontWall"))
            {
                GameManager.Instance.playerHealth--;
                GameManager.Instance.UpdateCurrentHealth();

                Destroy(transform.parent.gameObject);
            }
        }
}

