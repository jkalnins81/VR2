using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownDestroyParts : MonoBehaviour
{

    public void DestroyMe()
    {
        Destroy(gameObject, 3f);
    }
    
}
