using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
public class helght : NetworkBehaviour
{

    public float NetworkedHealth  = 100;
    [Networked]
    public bool live { get; set; } = true;
    public GameObject body,camm,handd;
    public polygon_fps_controller pc;
    public controlPlayer cp;
    public Vector3 p1, p2;
    public Animator an;

    public Text health;
    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {
        health.text = NetworkedHealth.ToString();
        if(NetworkedHealth<=0)
        {
            live = false;
            an.SetBool("death", true);
            
            if (HasStateAuthority)
            {
                //NetworkedHealth = 100;
                camm.SetActive(true);
                handd.SetActive(false);
                body.SetActive(true);
                pc.enabled = false;
                cp.enabled = false;
                Invoke("reseet", 5);
                
            }

            StartCoroutine(reseetsy());
        }

    }

    [Rpc]
    public void DealDamageRpc(float damage,SHOOT sot)
    {
        if(NetworkedHealth>0)
        {
          if (NetworkedHealth - damage <= 0)
           {
                sot.kills++;
           }

            NetworkedHealth -= damage;
        }
    }

    public void reseet()
    {
        //NetworkedHealth = 100;
        cp.enabled = true;
        handd.SetActive(true);
        body.SetActive(false);
        camm.SetActive(false);
        pc.enabled = true;
        an.SetBool("death", false);
        
    }
    IEnumerator reseetsy()
    {
        NetworkedHealth = 100;
        
        yield return new WaitForSeconds(6f);
        live = true;
        trle();
    }

    void trle()
    {
        cp.ch.enabled = false; // Disable the Character Controller temporarily
        
        if (Runner.LocalPlayer.ToString()=="[Player:0]")
        {
            cp.ch.transform.position = p1;
        }
        else if (Runner.LocalPlayer.ToString() == "[Player:1]")
        {
            cp.ch.transform.position = p2;
        }
        cp.ch.enabled = true; // Re-enable the Character Controller
    }

}
