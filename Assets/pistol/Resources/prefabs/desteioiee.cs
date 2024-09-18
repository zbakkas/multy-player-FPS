using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desteioiee : MonoBehaviour
{
    public float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeDestroy);
    }
}
