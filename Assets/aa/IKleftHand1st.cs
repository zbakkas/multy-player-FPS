using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKleftHand1st : MonoBehaviour
{

    [SerializeField]
    private Animator animator_1st = null;

    private GripManager gripManager1st;

    [SerializeField]
    private GameObject Weapons1st = null;
   
    [Space(10f)]
    public bool Grip;
    public bool reload;
    private float Weight = 1;
    private float Velocity;

    void Start()
    {
        gripManager1st = Weapons1st.GetComponent<GripManager>();
        //gripManager1st.Animator_1st = animator_1st;
    }
    void OnAnimatorIK()
    {
        if (gripManager1st == null)
        {
            gripManager1st = Weapons1st.GetComponent<GripManager>();
            //gripManager1st.Animator_1st = animator_1st;
        }
       
        if (animator_1st && gripManager1st != null)
        {
            if (reload == true)
            {
                Weight = Mathf.SmoothDamp(Weight, 0, ref Velocity, 0.1f);
                animator_1st.SetLayerWeight(1, Weight);
               
            }
            else
            {
                Weight = Mathf.SmoothDamp(Weight, 1, ref Velocity, 0.1f);
                animator_1st.SetLayerWeight(1, Weight);
               
            }
            if (animator_1st.GetBool("Grip"))
            {
                Transform IK_Grip = gripManager1st.TransformOutIKArm;
                animator_1st.SetBool("Grip", Grip);
                animator_1st.SetIKPosition(AvatarIKGoal.LeftHand, IK_Grip.position);
                animator_1st.SetIKPositionWeight(AvatarIKGoal.LeftHand, Weight);
                animator_1st.SetIKRotation(AvatarIKGoal.LeftHand, IK_Grip.rotation);
                animator_1st.SetIKRotationWeight(AvatarIKGoal.LeftHand, Weight);
            }
            else
            {
                Transform IK_Hand = gripManager1st.TransformOutIKArm;
                animator_1st.SetBool("Grip", Grip);
                animator_1st.SetIKPosition(AvatarIKGoal.LeftHand, IK_Hand.position);
                animator_1st.SetIKPositionWeight(AvatarIKGoal.LeftHand, Weight);
                animator_1st.SetIKRotation(AvatarIKGoal.LeftHand, IK_Hand.rotation);
                animator_1st.SetIKRotationWeight(AvatarIKGoal.LeftHand, Weight);
            }
        }
    }
}
