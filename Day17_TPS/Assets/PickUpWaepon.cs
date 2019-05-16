using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWaepon : StateMachineBehaviour
{
    PlayerController pc;
    Transform weaponHolder;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc = animator.GetComponent<PlayerController>();
        weaponHolder = pc.weaponHolder;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(weaponHolder.childCount == 0 && stateInfo.normalizedTime > 0.22f)
        {
            GameObject weapon = pc.GetNearestWeaponIn(radius: 1.5f, angle: 180f, weaponTag: "RightWeapon");
            if (weapon == null)
                return;
            weapon.GetComponent<Rigidbody>().isKinematic = true;
            Collider[] colliders = weapon.GetComponents<Collider>();
            foreach (var c in colliders)
                c.enabled = false;
            weapon.transform.SetParent(weaponHolder);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
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
// 무기 버리기 숙제.
// 키눌렀을 시 등 뒤에 장착(thisAmr), 등에서 꺼내는거 (isAmr);
//Mixamo에서 애니메이션 다운.
// 공격하기 콤보 공격
// 무기 없는데 줍는 행동하는 것 고치기
// 장착 상태에서 공격키 눌럿을 때 바로 발도하면서 때리기 콤보와 연결