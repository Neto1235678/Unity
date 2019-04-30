using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start() // Start는 코루틴 가능
    {
        print("Start()");
        StartCoroutine(Todo());
        print("C");
        yield return null;
        print("D");
    }

   IEnumerator Todo()
    {
        print("A");
        yield return null;
        print("B");
    }


    // Runtime Error ! : Scrip error (CoroutineStart) : Update() can not be a coroutine.
    //// Update is called once per frame
    //IEnumerator Update()
    //{
    //    yield return null; // 업데이트 함수에 코루틴을 쓰면 멈춘다.
    //}
}
