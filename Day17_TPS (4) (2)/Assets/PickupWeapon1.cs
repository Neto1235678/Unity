using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon1 : StateMachineBehaviour
{
    PlayerController pc;
    Transform RightweaponHolder;
    Transform LeftweaponHolder;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc = animator.GetComponent<PlayerController>();
        RightweaponHolder = pc.RightweaponHolder;
        LeftweaponHolder = pc.LeftweaponHolder;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (LeftweaponHolder.childCount == 0 && stateInfo.normalizedTime > 0.22f)
        {
            GameObject weapon = pc.GetNearestWeaponIn(radius: 1.5f, angle: 180f, weaponTag: "LeftWeapon");

            if (weapon == null)
                return;
            else
            weapon.GetComponent<Rigidbody>().isKinematic = true;
            Collider[] colliders = weapon.GetComponents<Collider>();
            foreach (var c in colliders)
                c.enabled = false;
            weapon.transform.SetParent(LeftweaponHolder);
            weapon.transform.localPosition = new Vector3(-0.25f, 0.155f, -0.2f);
            weapon.transform.localRotation = Quaternion.identity;
            animator.SetInteger("HoldingWeaponId", weapon.GetComponent<WeaponType>().weaponId);         
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
