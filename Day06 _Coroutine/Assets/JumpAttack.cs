using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TripleJumpAttack());
        }
        print(transform.position);

    }

    IEnumerator TripleJumpAttack()
    {
        Jump(2f);
        yield return new WaitForSeconds(1.8f);
        Jump(2f);
        yield return new WaitForSeconds(1.8f);
        yield return WheelWindJump(5f);
    }

    IEnumerator WheelWindJump(float height)
    {
        Jump(height);
        rb.maxAngularVelocity = 100;
        rb.angularVelocity = Vector3.up * 30f;
        yield return new WaitForSeconds(0.8f);
        rb.angularDrag = 2f;
        yield return new WaitForSeconds(2f);
        rb.angularVelocity = Vector3.zero;
        rb.angularDrag = 0.5f;
    }

    private void Jump(float height)
    {

        Vector3 v = rb.velocity;
        v.y = Mathf.Sqrt(-2.0f * Physics.gravity.y * height); // height 값까지 점프하는 벨로시티 값 만들기.
        rb.velocity = v; // Type 1 
        //rb.AddForce(v, ForceMode.VelocityChange); // Type 2

    }
}
