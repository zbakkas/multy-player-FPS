using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
public class addKills : NetworkBehaviour
{
   
    [Networked(OnChanged = nameof(Updatekills))] public float kills { get; set; }
    public Text killsText1, killsText2;

    PlayerSpawner psw;

    // Start is called before the first frame update
    private void Start()
    {
        // Disable health text on the local player's UI
        if (HasStateAuthority)
        {
            killsText2.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HasStateAuthority)
        {
            killsText1.text = kills.ToString();
        }
    }
    protected static void Updatekills(Changed<addKills> ch)
    {
        // Update UI on all clients when health changes
        ch.Behaviour.killsText2.text = ch.Behaviour.kills.ToString();
    }

}
