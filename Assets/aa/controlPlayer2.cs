using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.EventSystems;
public class controlPlayer2 : NetworkBehaviour
{

    public CharacterController ch;
    public float movespeed;
    float speed;


    float jump = 0;
    public float isjump;
    public float timjump;



    public Animator an;
    Quaternion CurrentRot;
    public float MouseSensX = 50;
    public float MouseSensY = 5;
    public float x;
    public float Spine2;
    public GameObject hands;
    public bool run;
    public wopean wp;
    public Vector2 recouile;

    public AudioSource ADUI;
    public AudioClip jumpAudio, workAudio,runAudio;

    public bool locmouuus;
    // Start is called before the first frame update
    void Start()
    {
        speed = movespeed;
        run = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CurrentRot = transform.rotation;

        
    }
    //public GameObject hand;
    private void Update()
    {
        
    }

    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {



        MouseLocker();

        // Only move own player and not every other player. Each player controls its own player object.


        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        lookmous();
        ////
        if ((Input.GetKey(KeyCode.LeftShift) && vertical >= 0.80f && !an.GetBool("aim")) || (Input.GetKey(KeyCode.RightShift)&& vertical>=0.80f && !an.GetBool("aim")))
        {
            
                speed = movespeed * 2f;
                an.SetLayerWeight(3, 1);
                wp.an.SetBool("run", true);

            run = true;
        }
        else
        {
            run = false;
            an.SetLayerWeight(3, 0);
            wp.an.SetBool("run", false);
            speed = movespeed;
  
        }


        ////

        if (Input.GetKey(KeyCode.Space) && ch.isGrounded)
        {
            jump = isjump;
            //an.SetTrigger("IsJump");
            ADUI.clip = jumpAudio;
            ADUI.Play();
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



    
    public void lookmous()
    {
        //Animator_1st.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        x += (Input.GetAxis("Mouse X") * MouseSensX * Runner.DeltaTime) + recouile.x * Runner.DeltaTime;
        Quaternion X = Quaternion.AngleAxis(x, Vector3.up);
        transform.rotation = CurrentRot * X;


        Spine2+= (Input.GetAxis("Mouse Y") * -MouseSensY  * Runner.DeltaTime)+recouile.y *Runner.DeltaTime;
        Spine2 = Mathf.Clamp(Spine2, -85, 85);
        hands.transform.eulerAngles = new Vector3 (Spine2, hands.transform.eulerAngles.y, hands.transform.eulerAngles.z);
        an.SetFloat("Spine", (Spine2+85)/(85*2));

    }

    void MouseLocker()
    {
        // mouse lock
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        // mouse unlock
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
