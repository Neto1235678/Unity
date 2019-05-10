using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    Vector3 moveDirection = Vector3.zero;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(h, 0f, v).normalized;
        moveDirection *= moveSpeed;
        transform.LookAt(transform.position + moveDirection);

    }
}
