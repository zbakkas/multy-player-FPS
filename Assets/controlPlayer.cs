using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class controlPlayer : NetworkBehaviour
{

    public CharacterController ch;
    public float movespeed;
    float speed;


    float jump = 0;
    public float isjump;
    public float timjump;



    public Animator an;

    //PhotonView v;

    // Start is called before the first frame update
    void Start()
    {
        speed = movespeed;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }
    //public GameObject hand;
    public override void Spawned()
    {
        if (HasStateAuthority)
        {
           // hand.SetActive(true);
            //  Camera.GetComponent<FirstPersonCamera>().Target = GetComponent<NetworkTransform>().InterpolationTarget;
        }
    }

    // Update is called once per frame

    public override void FixedUpdateNetwork()
    {
        // Only move own player and not every other player. Each player controls its own player object.
        if (HasStateAuthority == false)
        {
            return;
        }
        if (IsProxy == true)
            return;

        if (Runner.IsForward == false)
            return;
 

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");


        ////
        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        {

            speed = movespeed * 2f;
            an.SetBool("run", true);
        }
        else
        {
            an.SetBool("run", false);
            speed = movespeed;
        }

        ////

        if (Input.GetKey(KeyCode.Space) && ch.isGrounded)
        {
            jump = isjump;
            //an.SetTrigger("IsJump");

        }
        else
        {
            if (ch.isGrounded == false)
            {
                jump -= isjump * timjump * Runner.DeltaTime;
              
            }

        }
        ///
        an.SetFloat("X", vertical);
        an.SetFloat("Y",horizontal);

        Vector2 vulompv = new Vector2(horizontal, vertical);
        vulompv.Normalize();


        //



        Vector3 velocity = (transform.forward * vulompv.y + transform.right * vulompv.x) * speed   + Vector3.up * jump;
        ch.Move(velocity * Runner.DeltaTime);


    }



    



 
}
