using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAttack : StateMachineBehaviour, IHitBoxResponder
{
    public int damage = 5;
    public bool enableMultipleHits = false;


    HitBox hitBox;
    bool entered;
    public void collisionWith(Collider collider, HitBox hitBox)
    {

        HurtBox hurTbox = collider.GetComponent<HurtBox>();
        //Debug.Log("Hit: " + collider.name);
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
        hr?.Hurt(damage, hitPoint, hitNormal, hitDirection, ReactionType.Stun);

    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitBox = animator.GetComponent<MonsterMove>().jumpAttcion;
        hitBox.SetResponder(this);
        hitBox.enableMultipleHits = this.enableMultipleHits;
        hitBox.StartCheckingCollsion();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (0.56 <= stateInfo.normalizedTime && stateInfo.normalizedTime <= 0.80)
        {
            hitBox.UpdateHitBox();
            if (!entered && stateInfo.normalizedTime >= 0.6f)
            {
                MonsterMove mm = animator.GetComponent<MonsterMove>();
                var fx = Instantiate(mm.jumpAttackFX, mm.transform.position, Quaternion.identity);
                Destroy(fx, 2f);

                AddForceToEny(200f, hitBox.transform.position, 5f, 5f);

                CameraShake cs = Camera.main.GetComponent<CameraShake>();
                cs.enabled = true;
                cs.StartCoroutine(cs.Shake(0.1f, 0.4f));
                entered = !entered;
            }
        }
    }

    private void AddForceToEny(float power, Vector3 explosionPosition, float radius ,float upwardsModifier)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach(var c in colliders)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if(rb != null)
            {
                //Debug.Log(rb.name);
                rb.AddExplosionForce(power, explosionPosition, radius, upwardsModifier);
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitBox.StopCheckingCollsion();
        entered = false;
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
