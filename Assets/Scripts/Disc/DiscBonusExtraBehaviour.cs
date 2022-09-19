using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscBonusExtraBehaviour : MonoBehaviour
{
   [SerializeField] private Collider[] colliders; 
    // Start is called before the first frame update
    void Start()
    {
        colliders = transform.GetComponents<Collider>(); 
        
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        
        //Activate colliders over time in order for disc not to kill itself
        StartCoroutine(ActivatingCollider());
        
        //Scale Disc
        StartCoroutine(ScaleOverTime(2f));
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator ActivatingCollider()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
    
    IEnumerator ScaleOverTime(float time)
    {
        Vector3 orgScale = gameObject.transform.localScale;
        Vector3 destinationScale = new Vector3(0.75f, 0.1f, 0.75f);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(orgScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

    }
}
