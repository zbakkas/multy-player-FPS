using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKleftHand3th : MonoBehaviour
{
    [SerializeField]
    private Animator animator_3th = null;

    private GripManager gripManager3th;

    [SerializeField]
    private GameObject Weapons3th = null;

    [Space(10f)]
    public bool Grip;
    public bool reload;
    private float Weight = 1;
    private float Velocity;

    void Start()
    {
        gripManager3th = Weapons3th.GetComponentInChildren<GripManager>();
        //gripManager3th.Animator_3th = animator_3th;
    }

    void OnAnimatorIK()
    {
        if (gripManager3th == null)
        {
            gripManager3th = Weapons3th.GetComponentInChildren<GripManager>();
           // gripManager3th.Animator_3th = animator_3th;
        }

        if (animator_3th && gripManager3th != null)
        {
            if (reload == true)
            {
                Weight = Mathf.SmoothDamp(Weight, 0, ref Velocity, 0.1f);
                animator_3th.SetLayerWeight(2, Weight);
            }
            else
            {
                if (animator_3th.GetBool("Lay") == true)
                {
                    if (animator_3th.GetFloat("Horizontal") > 0.1f || animator_3th.GetFloat("Horizontal") < -0.1f || animator_3th.GetFloat("Vertical") > 0.1f || animator_3th.GetFloat("Vertical") < -0.1f)
                    {
                        Weight = Mathf.SmoothDamp(Weight, 0, ref Velocity, 0.1f);
                        animator_3th.SetLayerWeight(2, Weight);
                    }
                    else
                    {
                        Weight = Mathf.SmoothDamp(Weight, 1, ref Velocity, 0.1f);
                        animator_3th.SetLayerWeight(2, Weight);
                    }
                }
                else
                {
                    Weight = Mathf.SmoothDamp(Weight, 1, ref Velocity, 0.5f);
                    animator_3th.SetLayerWeight(2, Weight);
                }               
            }
            
            if (animator_3th.GetBool("Grip"))
            {
                Transform IK_Grip = gripManager3th.TransformOutIKArm;
                animator_3th.SetBool("Grip", Grip);
                animator_3th.SetIKPosition(AvatarIKGoal.LeftHand, IK_Grip.position);
                animator_3th.SetIKPositionWeight(AvatarIKGoal.LeftHand, Weight);
                animator_3th.SetIKRotation(AvatarIKGoal.LeftHand, IK_Grip.rotation);
                animator_3th.SetIKRotationWeight(AvatarIKGoal.LeftHand, Weight);
            }
            else
            {
                Transform IK_Hand = gripManager3th.TransformOutIKArm;
                animator_3th.SetBool("Grip", Grip);
                animator_3th.SetIKPosition(AvatarIKGoal.LeftHand, IK_Hand.position);
                animator_3th.SetIKPositionWeight(AvatarIKGoal.LeftHand, Weight);
                animator_3th.SetIKRotation(AvatarIKGoal.LeftHand, IK_Hand.rotation);
                animator_3th.SetIKRotationWeight(AvatarIKGoal.LeftHand, Weight);
            }
        }
    }
}
