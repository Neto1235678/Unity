﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonChase : StateMachineBehaviour
{
    public float chaseSpeed = 2f;

    MonsterMove mm;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mm = animator.GetComponent<MonsterMove>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform target = animator.GetComponent<MonsterMove>().target;
        Vector3 dir = target.position - animator.transform.position;
        dir.y = 0;
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation,
                                                        Quaternion.LookRotation(dir),
                                                        0.1f);

        Vector3 move = animator.transform.forward * chaseSpeed * Time.deltaTime;
        mm.moveDirection = dir.magnitude > 0.5f ? move : Vector3.zero;


        //if(dir.magnitude > 1f)
        //{
        //    animator.transform.Translate(0, 0, chaseSpeed * Time.deltaTime);
        //    animator.SetBool("Reaction", false);
        //}
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
