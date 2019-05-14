using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float RotateSpeed;
    float MoveSpeed = 5f;
    Vector3 moveDirection = Vector3.zero;
    Rigidbody rb;
    public GameObject cmr;
    public float mouseSensitivityX = 2f;
    public float mouseSensitivityY = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        //moveDirection = new Vector3(h, 0f, v).normalized;
        //moveDirection *= moveSpeed;
        //transform.LookAt(transform.position + moveDirection);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1))
        {
            float mousePos = Input.mousePosition.x;
            float _mousePos = Input.mousePosition.y;

            cmr.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") );
            cmr.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") );


        }

    



        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (Input.GetKeyDown(KeyCode.D))
        //        transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        //}

    }

    //private void FixedUpdate()
    //{
    //    Vector3 move = moveDirection * Time.fixedDeltaTime;
    //    rb.MovePosition(rb.position + move);
    //}
}


// 좌우키 누르면 회전, 전진하면 앞으로 후진하면 뒤로
// 우클릭하고 회전 앞으로 이동 뒤로 이동 가능 좌우 누르면 이동
// 좌클릭하면 카메라만 회전 캐릭터 둘러보게끔 움직임가능, 회전가능
// 휠 줌인 줌아웃
// 더미 몸안에, 메인은 뒤에 있다. 메인에 마우스 룩 스크립트. 로테이션 스피드. 줌 스피드. 카메라 앵글 X
// 좌클릭 더미를 돌려서 좌클릭구현
// 실행하면 메인 카메라를 위로 어느정도 올린다
// 줌인은 더미 카메라를 기준으로 로컬값으면 메인 카메라 Z 축을 땅긴다.