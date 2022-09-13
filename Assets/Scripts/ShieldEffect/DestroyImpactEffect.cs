using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyImpactEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2);
        Vector3 eulerRotation = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }
}
