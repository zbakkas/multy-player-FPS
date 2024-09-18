using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ammo : MonoBehaviour
{
    public int Amoo;
    public int MaxAmoo  ;

   public Text Tamo, Tmaxamo;

    //
    public int Amoo2 = 15;

    public Animator an, an3p;///////

    bool relodd;

    public IKleftHand3th ik;////////
    public int maxAmoIndeath;//////

    public bool relodanimatin ,inrelod;

    public AudioSource ADUI;
    public AudioClip reloadAudio;

    // Start is called before the first frame update
    void Start()
    {
       relodanimatin = false;
        Amoo = Amoo2;
        relodd = true;
        maxAmoIndeath = MaxAmoo;/////
    }


    private void Update()
    {

        ///LAG REMOV THIS
        Tamo.text = Amoo.ToString();
        Tmaxamo.text = MaxAmoo.ToString();
        if ((Input.GetKeyDown(KeyCode.R) && Amoo < Amoo2 && MaxAmoo >= 1) || (Amoo == 0 && MaxAmoo > 0 && !relodanimatin && !inrelod))
        {


            an.SetBool("reload" ,true);
            an3p.SetBool("reload",true);/////
            ik.reload = true;/////
            inrelod = true;


        }
    }

    public void waitingRelod()
    {
        if (MaxAmoo >= Amoo2)
        {
            MaxAmoo -= Amoo2 - Amoo;
            Amoo += Amoo2 - Amoo;
        }
        if (MaxAmoo < Amoo2 && MaxAmoo - (Amoo2 - Amoo) >= 1)
        {
            MaxAmoo -= Amoo2 - Amoo;
            Amoo += Amoo2 - Amoo;

        }
        if (MaxAmoo - (Amoo2 - Amoo) < 0)
        {
            Amoo += MaxAmoo;
            MaxAmoo -= MaxAmoo;
        }
    }


    public void norelod()
    {
        relodanimatin = false;
        waitingRelod();
        ik.reload = false;//////
        an.SetBool("reload", false);
        an3p.SetBool("reload", false);/////

    }
    public void yesrelode()
    {
        relodanimatin = true;
        inrelod = false;

        ADUI.clip = reloadAudio;
        ADUI.Play();
    }


 

}
