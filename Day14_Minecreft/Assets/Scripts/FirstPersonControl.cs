using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControl : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float mouseSensitivityX = 2f;
    public float mouseSensitivityY = 2f;
    public float jumpHeight = 2f;
    public Transform groundChecker;
    public LayerMask groundMask;

    Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    bool isGrounded = false;
    RaycastHit hit;

    Transform cameraTranform;
    Rigidbody rb;
    float verticlaLockRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTranform = GetComponentInChildren<Camera>().transform;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.SphereCast(groundChecker.position, 0.5f, -transform.up, out hit, 0.2f, groundMask, QueryTriggerInteraction.Ignore);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(h, 0, v).normalized;
        moveDirection *= moveSpeed;

        //print(Input.GetAxis("Mouse X"));
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX); // GetAxis가 알아서 속도를 구해서 준다.

        verticlaLockRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
        verticlaLockRotation = Mathf.Clamp(verticlaLockRotation, -90, 60);
        cameraTranform.localEulerAngles = Vector3.left * verticlaLockRotation;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        //print(Input.GetAxis("Mouse Y"));
    }

    private void FixedUpdate()
    {


        //TransformPoint: position, rotation, scale
        //TransformDirection: rotation only // 방향만 의미가 있다.
        //TransformVector: rotation and scale only // 
        Vector3 move = transform.TransformDirection(moveDirection) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        //Gizmos.DrawSphere(groundChecker.position, 0.5f);
    }
}
