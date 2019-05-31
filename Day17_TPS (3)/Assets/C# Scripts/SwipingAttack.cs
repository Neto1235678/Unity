using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipingAttack : StateMachineBehaviour, IHitBoxResponder
{
    public int damage = 5;
    public bool enableMultipleHits = false;


    HitBox hitBox;
    public void collisionWith(Collider collider, HitBox hitBox)
    {

        HurtBox hurTbox = collider.GetComponent<HurtBox>();
        Debug.Log("Hit: " + collider.name);
        hurTbox.GetHitBy(damage); //debugging
        //collider.GetComponentInParent<Health>().DecreaseHP(damage);

        Vector3 from = hitBox.transform.position;
        Vector3 hitPoint;
        Vector3 hitNormal;
        Vector3 hitDirection;

        hitBox.GetContactInfo(from: from,
                       to: collider.ClosestPoint(from),
                       out hitPoint, out hitNormal, out hitDirection,
                       1 << LayerMask.NameToLayer("HurtBox"),
                       2f);

        BoxHitReaction hr = collider.GetComponentInParent<BoxHitReaction>();
        hr?.Hurt(damage, hitPoint, hitNormal, hitDirection, ReactionType.Head);

    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitBox = animator.GetComponent<MonsterMove>().leftHandHitBox;
        hitBox.SetResponder(this);
        hitBox.enableMultipleHits = this.enableMultipleHits;
        hitBox.StartCheckingCollsion();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (0.51 <= stateInfo.normalizedTime && stateInfo.normalizedTime <= 0.62)
        {
            hitBox.UpdateHitBox();
        }
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
