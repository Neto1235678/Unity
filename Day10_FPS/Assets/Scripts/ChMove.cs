using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    Vector3 moveDirection = Vector3.zero;
    Animator anim;
    Rigidbody rb;
    float h;
    float v;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(h, 0f, v).normalized;
        moveDirection *= moveSpeed;
        transform.LookAt(transform.position + moveDirection);
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("Speed", 0.5f);
            anim.speed = 3f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Speed", 0.5f);
            anim.speed = 3f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            anim.SetFloat("Speed", 0.5f);
            anim.speed = 3f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetFloat("Speed", 0.5f);
            anim.speed = 3f;
        }
        else
            anim.SetFloat("Speed", 0.3f);


    }

    private void FixedUpdate()
    {

        Vector3 move = moveDirection * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
        
    }
}
