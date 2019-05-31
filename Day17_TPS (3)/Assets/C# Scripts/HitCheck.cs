﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : StateMachineBehaviour, IHitBoxResponder
{
    public int damage = 5;
    public bool enableMultipleHits;

    HitBox hitBox;
    Dictionary<int, int> hitobjects;

    public void collisionWith(Collider collider, HitBox hitBox)
    {

        HurtBox hurTbox = collider.GetComponent<HurtBox>();
        //Debug.Log("Hit: " + collider.name);
        hurTbox.GetHitBy(damage); //debugging
        //collider.GetComponentInParent<Health>().DecreaseHP(damage);

        Vector3 cameraTargetPosition = hitBox.transform.root.Find("CameraTarget").transform.position;
        Vector3 hitPoint;
        Vector3 hitNormal;
        Vector3 hitDirection;

        hitBox.GetContactInfo(from: cameraTargetPosition,
                       to: collider.transform.root.transform.position,
                       out hitPoint, out hitNormal, out hitDirection,
                       1 << LayerMask.NameToLayer("HurtBox"),
                       2f);

        BoxHitReaction hr = collider.GetComponentInParent<BoxHitReaction>();
        hr?.Hurt(damage, hitPoint, hitNormal, hitDirection, ReactionType.Head);
        
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitBox = animator.GetComponent<PlayerController>().weaponHolder.GetComponentInChildren<HitBox>();
        hitBox.SetResponder(this);
        hitBox.enableMultipleHits = this.enableMultipleHits;
        hitBox.StartCheckingCollsion();
        hitobjects = new Dictionary<int, int>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(0.35 <= stateInfo.normalizedTime && stateInfo.normalizedTime <= 0.45)
            hitBox.UpdateHitBox();

        if (Input.GetKeyDown(KeyCode.C) && stateInfo.normalizedTime >= 0.5f)
        {
            animator.SetTrigger("ComboAttack");
        }
        
            


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //hitBox.StopCheckingCollsion();
        animator.SetBool("ComboAttack", false);
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

// 무기 단위로 정리, 줍고 차고 빼고 어택까지
// 코드 정리 및 몹 하나 넣기 판단까지, 필요하면 리액션까지.
// 점프 공중동작