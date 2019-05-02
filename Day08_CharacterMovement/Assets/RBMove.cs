using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMove : MonoBehaviour
{

    public float moveSpeed = 8f;
    public float jumpHeight = 2f;
    public LayerMask groundMask;
    public Transform groundCheck;
    RaycastHit hit;


    Rigidbody rb;
    Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //1
        //Ray ray = new Ray(transform.position, -transform.up);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, 1 + 0.1f))
        //    isGrounded = true;
        //else
        //    isGrounded = false;
        //Debug.DrawRay(ray.origin, ray.direction, Color.magenta, 0.2f);

        //2
        //isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, groundMask, QueryTriggerInteraction.Ignore);

        //3

        isGrounded = Physics.SphereCast(groundCheck.position, 0.5f, -transform.up, out hit, 0.2f, groundMask, QueryTriggerInteraction.Ignore);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(h, 0, v).normalized;
        moveDirection *= moveSpeed;
        transform.LookAt(transform.position + moveDirection);
    }

    private void FixedUpdate()
    {
        Vector3 move = moveDirection * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(groundCheck.position, 0.5f);
    }
}
