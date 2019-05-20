using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeIdie : StateMachineBehaviour
{

    PlayerController pc;
    Transform AxeHold;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc = animator.GetComponent<PlayerController>();
        AxeHold = pc.AxeHold;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (AxeHold.childCount == 0 && stateInfo.normalizedTime > 0.22f)
        {
            GameObject weapon = pc.GetNearestWeaponIn(radius: 1.5f, angle: 180f, weaponTag: "RightWeapon");
            if (weapon == null)
                return;
            weapon.GetComponent<Rigidbody>().isKinematic = true;
            Collider[] colliders = weapon.GetComponents<Collider>();
            foreach (var c in colliders)
                c.enabled = false;
            weapon.transform.SetParent(AxeHold);
            weapon.transform.localPosition = new Vector3(0f, 0f, -0.1f);
            weapon.transform.localRotation = Quaternion.EulerRotation(90f, 190f, 0f);
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
