using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : StateMachineBehaviour, IHitBoxResponder
{
    public int damage = 5;

    HitBox hitBox;
    Dictionary<int, int> hitobjects;

    public void collisionWith(Collider collider)
    {

        HurtBox hurTbox = collider.GetComponent<HurtBox>();
        Debug.Log("Hit: " + collider.name);
        int id = collider.transform.root.gameObject.GetInstanceID();
        if (!hitobjects.ContainsKey(id))
            hitobjects[id] = 1;
        else
        {
            hitobjects[id] += 1;
            return;
        }
            


        hurTbox.GetHitBy(damage); //debugging
        //collider.GetComponentInParent<Health>().DecreaseHP(damage);
        Vector3 cameraTargetPosition = hitBox.transform.root.Find("CameraTarget").transform.position;
        RaycastHit hit;
        Vector3 hitPoint = collider.transform.position;
        Vector3 hitNormal = cameraTargetPosition - hitPoint;
        hitNormal = hitNormal.normalized;
        Vector3 hitDirection = -hitNormal;
        if (Physics.Raycast(cameraTargetPosition,
                            hitDirection,
                            out hit,
                            2f,
                            1 << LayerMask.NameToLayer("HurtBox"),
                            QueryTriggerInteraction.Collide))
        {
            hitPoint = hit.point;
            hitNormal = hit.normal;
            hitDirection = hitPoint - cameraTargetPosition;
            hitDirection = hitDirection.normalized;
        }


        Debug.Log("OneHit: " + collider.name);
        Debug.DrawLine(cameraTargetPosition, hitPoint, Color.yellow, 2f);
        Debug.DrawLine(hitPoint, hitPoint + hitNormal, Color.magenta, 2f);
        Debug.DrawLine(hitPoint, hitPoint + hitDirection, Color.cyan, 2f);
        BoxHitReaction hr = collider.GetComponentInParent<BoxHitReaction>();
        hr?.Hurt(damage, hitPoint, hitNormal, hitDirection);
        
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitBox = animator.GetComponent<PlayerController>().weaponHolder.GetComponentInChildren<HitBox>();
        hitBox.SetResponder(this);
        hitBox.StartCheckingCollsion();
        hitobjects = new Dictionary<int, int>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(0.35 <= stateInfo.normalizedTime && stateInfo.normalizedTime <= 0.45)
            hitBox.UpdateHitBox();

  
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitBox.StopCheckingCollsion();
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


// 코드 정리 및 몹 하나 넣기 판단까지, 필요하면 리액션까지.