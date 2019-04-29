using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seletion0 : MonoBehaviour
{

    public float angle = 90f;
    public float duration = 1f;

    bool isRotating = false;
    float remainingAngle;
    float remainingDuration;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRotating = true;
            remainingAngle = angle;
            remainingDuration = duration;
        }

        if(isRotating)
        {
            float anglePerFrame = (remainingAngle / remainingDuration) * Time.deltaTime;
            if(remainingAngle < anglePerFrame)
            {
                anglePerFrame = remainingAngle;
                isRotating = false;
            }
            transform.Rotate(Vector3.up * anglePerFrame);
            remainingAngle -= anglePerFrame;
            remainingDuration -= Time.deltaTime;
        }
    }
}


// 코루틴으로 바꾸기
// 상태 3개가 필요. 코루틴으로
// 리지바디로 점프하는 힘 주기
// 리지바디 에드코트 함수 사용.(회전을 거는 힘)
// rb.maxAngularVelocity =100f
// rb.AngularVelocity = Vector3.up * 30;
// angular drag를 크게 주면 회전을 방해한다.