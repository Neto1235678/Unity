using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool onGround;
    float jumpPressure;
    float minjump;
    float maxjumpPressure;

    Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        jumpPressure = 0f;
        minjump = 2f;
        maxjumpPressure = 10f;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(onGround)
        {
            if(Input.GetButton("Jump"))
            {
                if(jumpPressure < maxjumpPressure)
                {
                    jumpPressure += 10f * Time.deltaTime;
                }
                else
                {
                    jumpPressure = maxjumpPressure; 
                }
                anim.SetFloat("JumoPressure", jumpPressure + minjump);
                anim.speed = 1f + (jumpPressure * 0.15f);
            }
            else
            {
                if(jumpPressure > 0f)
                {
                    jumpPressure += minjump;
                    rb.velocity = new Vector3(0f, jumpPressure, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                    anim.SetFloat("JumoPressure", 0f);
                    anim.SetBool("OnGround", onGround);
                    anim.speed = 0.1f;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            anim.SetBool("OnGround", true);
        }
    }
}
