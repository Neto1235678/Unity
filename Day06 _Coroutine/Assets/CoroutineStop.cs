using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStop : MonoBehaviour
{
    //http://theeye.pe.kr/archives/2725
    //// 1
    //IEnumerator Start()
    //{
    //    yield return StartCoroutine("Todo", 2f);
    //}

    //IEnumerator Todo(float someParameter)
    //{
    //    while (true)
    //    {
    //        print("someParameter: " + someParameter);
    //        yield return new WaitForSeconds(1f);
    //    }
    //}

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StopCoroutine("Todo"); // yield return StartCoroutine("Todo", 2f); 쌍으로 돌아야한다.
    //    }
    //}



    //// 2:
    //IEnumerator co;
    //void Start()
    //{
    //    co = Todo(2f, "string");
    //    StartCoroutine(co);
    //}
    //IEnumerator Todo(float someParameter, string str)
    //{
    //    while (true)
    //    {
    //        print("someParameter: " + someParameter + str);
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StopCoroutine(co); // yield return StartCoroutine("Todo", 2f); 쌍으로 돌아야한다.
    //    }
    //}



    // 3:
    Coroutine co, co2;
    void Start()
    {
        co = StartCoroutine( Todo(2f, "string") );
        co2 = StartCoroutine( Todo(2f, "string") );

    }
    IEnumerator Todo(float someParameter, string str)
    {
        while (true)
        {
            print("someParameter: " + someParameter + str);
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines(); // yield return StartCoroutine("Todo", 2f); 쌍으로 돌아야한다.
        }
    }
}
