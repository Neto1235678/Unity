using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Start()");
        StartCoroutine(Todo());
        print("B");
        print("N");
    }

    IEnumerator Todo()
    {
        print("A");
        yield return null; // 다음 업데이트 출력 때 까지 대기.
        print("C");
        yield return new WaitForSeconds(Time.deltaTime);
        print("D");
        yield return StartCoroutine(NewTodo());
        print("G");
    }

    IEnumerator NewTodo()
    {
        print("E");
        yield return new WaitForSeconds(1f);
        print("F");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
