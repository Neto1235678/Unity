using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWeapon1 : StateMachineBehaviour
{
    PlayerController pc;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc = animator.GetComponent<PlayerController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pc.LeftweaponHolder.childCount == 1)
        {
            Transform weaponHoler = animator.GetComponent<PlayerController>().LeftweaponHolder;
            Transform weapon = weaponHoler.GetChild(0);
            foreach (var c in weapon.GetComponents<Collider>())
                c.enabled = true;
            weapon.SetParent(null);
            weapon.GetComponent<Rigidbody>().isKinematic = false;
            animator.SetInteger("HoldingWeaponId", 0);
        }
        else
            return;

    }

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
