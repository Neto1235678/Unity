using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // 비용이 있는 함수. 그렇기에 시작 전에 담아서 사용
    }

    private void FixedUpdate() // 물리 시뮬레이션은 Fixed에 넣어야된다. 가변적으로 바뀌면 물리 시뮬레이션도 가변적이다.
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 700f); 
        }
    }
}
