using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class wopean : NetworkBehaviour
{
    public GameObject [] woapeans;
    public Animator an;
    [Networked]
    public int zz { get; set; } = 0;



    public Transform tpweapnsholder;
    //public int xx = 0;
    // Start is called before the first frame update
    public override void Spawned()
    {
        offWopeans();
        woapeans[0].SetActive(true);
        an = woapeans[0].GetComponent<Animator>();
        SetWeaponnRPC(0);
    }

    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                zz = 0;
 
                // xx = 0;
                offWopeans();
                woapeans[zz].SetActive(true);
                an = woapeans[zz].GetComponent<Animator>();

                 SetWeaponnRPC(zz);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                zz = 1;
                // xx = 0;
                offWopeans();
                woapeans[zz].SetActive(true);
                an = woapeans[zz].GetComponent<Animator>();
                SetWeaponnRPC(zz);
            }
        }
       /*
         if (switchh)
         {
            for (int i = 0; i < woapeans.Length; i++)
            {
                woapeans3p[i].SetActive(false);
            }
            woapeans3p[zz].SetActive(true);
             grp.TransformOutIKArm = grp.iks[zz];
            
        }
        
        */
        
    
    }
    [Rpc]
    public void SetWeaponnRPC(int _weaponindx)
    {
        foreach( Transform _weapon in tpweapnsholder)
        {
            _weapon.gameObject.SetActive(false);
        }
        tpweapnsholder.GetChild(_weaponindx).gameObject.SetActive(true);
        tpweapnsholder.gameObject.GetComponent<GripManager>().TransformOutIKArm = tpweapnsholder.gameObject.GetComponent<GripManager>().iks[_weaponindx];
    }

    private void offWopeans()
    {
        for (int i = 0; i < woapeans.Length; i++)
        {
            woapeans[i].SetActive(false);
        }
    }
}
