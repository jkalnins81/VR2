using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FrontWall"))
            {
                GameManager.Instance.TakeDamage(damage);
                GameManager.Instance.UpdateCurrentHealth();

                Destroy(transform.parent.gameObject);
            }
        }
}

