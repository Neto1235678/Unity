using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobChaseNavMesh : StateMachineBehaviour
{
    public float chaseSpeed = 2f;

    MonsterMove mm;
    NavMeshAgent nmAgent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mm = animator.GetComponent<MonsterMove>();
        nmAgent = animator.GetComponent<NavMeshAgent>();
        nmAgent.speed = chaseSpeed;
        nmAgent.isStopped = false;
        mm.GetComponent<Rigidbody>().isKinematic = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform target = animator.GetComponent<MonsterMove>().target;
        Vector3 dir = target.position - animator.transform.position;
        dir.y = 0;

        nmAgent.destination = target.position;

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Combat.MeleeChase1")
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Combat.MeleeChase")) // 
        {
            nmAgent.isStopped = true;
            mm.GetComponent<Rigidbody>().isKinematic = false;
        }
        
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

// 버그 고치기
// 로밍 넣기

