using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class wwoappnss :  NetworkBehaviour
{
    [Networked]
    public int live { get; set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            live = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            live = 1;
        }
    }
}
