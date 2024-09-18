using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.EventSystems;
public class shoot : NetworkBehaviour
{

    Ray ay;
    RaycastHit hit;

    public Transform P1;
    public Transform P2;
    public Transform camm,hd;
    public Vector3 hdp;
    bool aim;
    public GameObject scrole;
    Vector3 camStarte;
    public float rangshoot;

    public ammo a;
    public Animator an, an3p;

    public GameObject muzzl,muzzlDamage,bulletPrefab;
    public Transform p3;

    public int Damaggun;

    public bool outoShot;
    float timeStamp;
    public float fireRate;
    public addKills kill;

    public controlPlayer2 cp;
    public float recoilGUN;
    public Vector2 vrecoilGUN;

    public AudioSource ADUI;
    public AudioClip fire,noammoFire;


    // Start is called before the first frame update
    void Start()
    {
        aim = true;
        camStarte = camm.localPosition;
        kill = gameObject.GetComponentInParent<addKills>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && a.relodanimatin == false && !outoShot&& a.Amoo > 0 && !an.GetBool("run") && !an.GetBool("shoot")&& !EventSystem.current.IsPointerOverGameObject())//
        {

            
                ADUI.clip = fire;
                ADUI.Play();

                shotting();
                an.SetBool("shoot", true);
                an3p.SetBool("shoot", true);
                
            

        }
        else if (Input.GetButton("Fire1") && a.relodanimatin == false && outoShot && a.Amoo > 0 && !an.GetBool("run")&& !EventSystem.current.IsPointerOverGameObject())//
        {

           
                timeStamp = timeStamp - Time.deltaTime;
                if (timeStamp <= 0)
                {

                    cp.recouile.x =  Random.Range(vrecoilGUN.x, vrecoilGUN.y);
                    cp.recouile.y = recoilGUN;

                    ADUI.clip = fire;                 
                    ADUI.Play();

                    an.SetBool("shoot", true);
                    an3p.SetBool("shoot", true);
                    timeStamp = fireRate;
                    shotting();
                }
            
           
        }
        else
        {
            if (outoShot)
            {
                an.SetBool("shoot", false);
                an3p.SetBool("shoot", false);
            }

            cp.recouile.x = 0;
            cp.recouile.y = 0;
        }

        if(Input.GetButtonDown("Fire1")&& a.Amoo <= 0)
        {
            ADUI.clip = noammoFire;
            ADUI.Play();
        }

        ////aim

        if(Input.GetButtonDown("Fire2"))
        {
            if(aim && a.relodanimatin == false)
            {
                aim = false;
                hd.localPosition = hdp;
                an.SetBool("aim", true);
                an3p.SetBool("aim", true);
                scrole.SetActive(false);
            }
            else
            {
                aim = true;
                hd.localPosition = camStarte;
                an.SetBool("aim", false);
                an3p.SetBool("aim", false);
                scrole.SetActive(true);
            }

        }
        if(!aim && a.relodanimatin)
        {
            aim = true;
            hd.localPosition = camStarte;
            an.SetBool("aim", false);
            an3p.SetBool("aim", false);
            scrole.SetActive(true);
        }
    }

    public void shotting()
    {

        a.Amoo = a.Amoo - 1;

        ay.origin = P1.position;
        ay.direction = P2.position - P1.position;
        ///
        Runner.Spawn(bulletPrefab, p3.position, p3.rotation);

        //
        if (Physics.Raycast(ay, out hit, rangshoot))
        {
            Debug.DrawLine(ay.origin, hit.point, Color.red, 1f); //khat mkan rasasa
                                                                 //EVCTE MAZZL


            helthPlayer targetanim = hit.collider.GetComponentInParent<helthPlayer>();

            if (hit.collider.tag=="legs")
            {
                damageFX();
               targetanim.DamageRpc(Damaggun/3, kill);

            }
            else if (hit.collider.tag == "chest")
            {
                damageFX();
                targetanim.DamageRpc(Damaggun/2, kill);

            }
            else if (hit.collider.tag == "head")
            {
                damageFX();
               targetanim.DamageRpc(Damaggun, kill);

            }
            else
            {
                var rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                var effect = Instantiate(muzzl, hit.point, rotation) as GameObject;
                effect.transform.SetParent(vObjectContainer.root, true);
           }

        }
    }
    public void damageFX()
    {
        var rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
        var effect = Instantiate(muzzlDamage, hit.point, rotation) as GameObject;
        effect.transform.SetParent(vObjectContainer.root, true);
    }

    public void shootAnimationSingle()
    {

        an.SetBool("shoot", false);
        an3p.SetBool("shoot", false);

    }
}
