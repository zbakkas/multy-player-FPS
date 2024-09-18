using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class buliit : NetworkBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Runner.DeltaTime);
        Destroy(gameObject, 4);

    }
}
