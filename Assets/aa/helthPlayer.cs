using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
public class helthPlayer : NetworkBehaviour
{
    
    public float NetworkedHealth =100;
    [Networked]
    public bool death { get; set; } = true;
    public Text health;
    public Animator an;
    public GameObject hands, body,cam;
    public controlPlayer2 cp;
    public ammo amo;
    PlayerSpawner psw;
    public GameObject damagaImaage;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
        psw = GameObject.Find("manatrger").GetComponent<PlayerSpawner>();
    }

    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {
        health.text = NetworkedHealth.ToString();
        if(NetworkedHealth<=0 && !death)
        {
            if (HasStateAuthority)
            {
                death = true;
                an.SetBool("death", true);
                an.SetLayerWeight(3, 1);
                body.SetActive(true);
                cam.SetActive(true);
                hands.SetActive(false);
                cp.enabled = false;
                amo.MaxAmoo = amo.maxAmoIndeath;
                amo.Amoo = amo.Amoo2;
                Invoke("deathComplete", 5);
            }

            //
            StartCoroutine(reseetsy());
            //NetworkedHealth = 100;
        }
        if (damagaImaage.activeSelf)
        {
                Invoke("da", 0.4f);

        }
        
        

    }
    [Rpc]
    public void DamageRpc(float damage, addKills sot)
    {
        if (NetworkedHealth > 0 && !death)
        {
            if (NetworkedHealth - damage <= 0)
            {
                sot.kills++;
                Debug.Log("kill");
            }
            damagaImaage.SetActive(true);
            NetworkedHealth -= damage;
        }
    }
    public void deathComplete()
    {
        an.SetBool("death", false);
        an.SetLayerWeight(3, 0);
       // NetworkedHealth = 100;
        cp.enabled = true;
        body.SetActive(false);
        cam.SetActive(false);
        hands.SetActive(true);
        death = false;
        trle();
    }
    IEnumerator reseetsy()
    {
        yield return new WaitForSeconds(4f);
        NetworkedHealth = 100;
    }

    void trle()
    {
        cp.ch.enabled = false; // Disable the Character Controller temporarily

       // if (Runner.LocalPlayer.ToString() == "[Player:0]")
       // {
           cp.ch.transform.position = psw.p[Random.Range(0, psw.p.Length)].position;
      //  }
      //  else if (Runner.LocalPlayer.ToString() == "[Player:1]")
        //{
         //   cp.ch.transform.position = psw.p[Random.Range(0, psw.p.Length)].position;
      //  }
        cp.ch.enabled = true; // Re-enable the Character Controller
    }


    void da()
    {
        damagaImaage.SetActive(false);
    }
}
