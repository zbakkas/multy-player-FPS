using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class noansy : MonoBehaviour
{
    public MonoBehaviour[] localScripts;
    public GameObject[] localObjects,deiblee;
    ///public override void Spawned()
    void Start()
    {
        NetworkObject thiiis = GetComponent<NetworkObject>();
      if (thiiis.HasStateAuthority)
      {
            for (int i = 0; i < localScripts.Length; i++)
            {
                localScripts[i].enabled = true;
            }
            for (int i = 0; i < localObjects.Length; i++)
            {
                localObjects[i].SetActive(true);
            }
            for (int i = 0; i < deiblee.Length; i++)
            {
                deiblee[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
