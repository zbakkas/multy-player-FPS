using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Fusion;

public class SHOOT : NetworkBehaviour
{
    Ray ay;
    RaycastHit hit;

    public Transform P1;
    public Transform P2;

    public float rangshoot;

    public ammo a;
   public Animator an;
    
    public GameObject muzzl;

    public int Damaggun;
    [Networked]
    public int kills { get; set; } = 0;
    public Text kil;

    public bool outoShot;
    float timeStamp;
    public float fireRate;
    public float recoilGUN;
    public Vector2 recoilGUNY;
    public polygon_fps_controller poly;
    public float camaim;

    // Start is called before the first frame update

    void Start()
    {
 
       a.relodanimatin = false;

    }



    // Update is called once per frame
    void Update()
    {
        kil.text = kills.ToString();

         if (Input.GetButtonDown("Fire1") && a.relodanimatin == false &&!outoShot )//
         {

             if (a.Amoo > 0)
             {
                 shotting();
                an.SetTrigger("shoot");
             }
         }
        else if (Input.GetButton("Fire1") && a.relodanimatin == false && outoShot)//
        {

            if (a.Amoo > 0)
            {
                timeStamp = timeStamp - Time.deltaTime;
                if (timeStamp <= 0)
                {
                    poly.recoil = recoilGUN;
                    poly.recoilY = Random.Range(recoilGUNY.x, recoilGUNY.y);
                    an.SetTrigger("shoot");
                    timeStamp = fireRate;
                    shotting();
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))//
        {

         
            poly.recoil = 0;
            poly.recoilY = 0;

           
        }
        if (Input.GetButton("Fire2") && a.relodanimatin == false)//
        {

            an.SetBool("aim",true);

        }
        else
        {
            an.SetBool("aim", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            an.SetBool("run", true);
        }
        else
        {
            an.SetBool("run", false);
        }
    }

    public void shotting()
    {



        a.Amoo = a.Amoo - 1;

        ay.origin = P1.position;
        ay.direction = P2.position - P1.position;
        ///
        //
        if (Physics.Raycast(ay, out hit,rangshoot))
        {
            Debug.DrawLine(ay.origin, hit.point, Color.red, 1f); //khat mkan rasasa
                                                                 //EVCTE MAZZL


            helght targetanim = hit.collider.GetComponent<helght>();

            if (targetanim)
            {
               if (targetanim.live && targetanim.NetworkedHealth > 0)
               {

                   
                    targetanim.DealDamageRpc(Damaggun,this);

                }


            }
            else
          {
                var rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                var effect = Instantiate(muzzl, hit.point, rotation) as GameObject;
                effect.transform.SetParent(vObjectContainer.root, true);
            }

        }
    }


}
     