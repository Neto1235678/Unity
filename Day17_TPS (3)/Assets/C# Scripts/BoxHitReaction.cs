using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReactionType
{
    None = 0,
    Head,
    Body,
    Stomach,
    Stun
}


public class BoxHitReaction : MonoBehaviour
{
    public GameObject hitFXPrefab;
    public GameObject stunFXPrefab;
    public Transform stunFXPos;

    Rigidbody rb;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    
    public void Hurt(int damage, Vector3 hitPoint, Vector3 hitMormal, Vector3 hitDorection, ReactionType reactionType)
    {

        if(anim != null 
           && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Reaction")
           && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Invincble")
           && !anim.IsInTransition(0))
        {
            anim.SetTrigger("Reaction");
            anim.SetInteger("ReactionType", (int)reactionType);

            if(reactionType == ReactionType.Stun)
            {
                GameObject stunfx = Instantiate(stunFXPrefab, stunFXPos.position, Quaternion.LookRotation(Vector3.up), stunFXPos);
                Destroy(stunfx, 2.8f);
            }
        }


       GetComponent<Health>().DecreaseHP(damage);
        GameObject fx = Instantiate(hitFXPrefab, hitPoint, Quaternion.identity);
        Destroy(fx, 1.5f);


        //2
        //rb?.AddForce(hitDorection * 5f, ForceMode.VelocityChange);


        //1
        if (rb != null)
            rb.velocity += hitDorection;
        // 1, 2의 두 코드가 값이 동일하지 않다.
    }

}
