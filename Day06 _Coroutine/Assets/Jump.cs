using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    bool floor = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // 비용이 있는 함수. 그렇기에 시작 전에 담아서 사용
        StartCoroutine(Todo());
    }

    IEnumerator Todo()
    {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * 500f);
            }
        
        yield return null;
        StartCoroutine(Tobo2());



    }

    IEnumerator Tobo2()
    {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * 500f);
                //rb.angularVelocity = Vector3.up * 60;
                //rb.angularDrag = 1;
            }
     
        yield return null;
        StartCoroutine(Tobo3());

    }

    IEnumerator Tobo3()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * 500f);
                rb.angularVelocity = Vector3.up * 60;
                rb.angularDrag = 1;
            }
        yield return null;
        StartCoroutine(Todo());
    }

    private void Update() // 물리 시뮬레이션은 Fixed에 넣어야된다. 가변적으로 바뀌면 물리 시뮬레이션도 가변적이다.
    {
        //if (floor == false)
        //{
        //    floor = true;
        //}
        //else
        //{
        //    floor = false;
        //}
        //if (floor == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        rb.AddForce(Vector3.up * 500f);
        //        rb.angularVelocity = Vector3.up * 60;
        //        rb.angularDrag = 1;
        //    }
        //}
        
    }
}

// 코루틴으로 바꾸기
// 상태 3개가 필요. 코루틴으로
// 리지바디로 점프하는 힘 주기
// 리지바디 에드코트 함수 사용.(회전을 거는 힘)
// rb.maxAngularVelocity =100f
// rb.AngularVelocity = Vector3.up * 30;
// angular drag를 크게 주면 회전을 방해한다.