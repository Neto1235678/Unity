﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : StateMachineBehaviour, IHitBoxResponder
{

    HitBox hitbox;
    PlayerController pc;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc = animator.GetComponent<PlayerController>();
        hitbox = pc.weaponHolder.GetComponentInChildren<HitBox>();

        hitbox.SetResponder(this);
        if (stateInfo.normalizedTime > 0.33f)
            hitbox.StartCheckingCollsion();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stateInfo.normalizedTime > 0.31f)
        {
            hitbox.UpdateHitBox();
        }
        
  
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        hitbox.StopCheckingCollsion();
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

    public void collisionWith(Collider collider)
    {
        Debug.Log("Hit");

    }
}