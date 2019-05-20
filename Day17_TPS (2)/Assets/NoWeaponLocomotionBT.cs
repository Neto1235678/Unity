﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeaponLocomotionBT : StateMachineBehaviour
{
    public float moveSpeed = 4f;
    PlayerController pc;
    GameObject ch;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc = animator.GetComponent<PlayerController>();
        pc.moveSpeed = moveSpeed;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc.FrameMove();



        if (Input.GetKeyDown(KeyCode.E) && pc.weaponHolder.childCount == 0)
        {
            GameObject weapon = pc.GetNearestWeaponIn(radius: 1.5f, angle: 85f, weaponTag: "RightWeapon");
            if (weapon == null)
                return;
            else
            animator.SetTrigger("PickUpWaepon");
        }
      
        if (Input.GetKeyDown(KeyCode.X) && pc.AxeHold.childCount > 0)
        {
            animator.SetTrigger("OnAxeIdie");
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
