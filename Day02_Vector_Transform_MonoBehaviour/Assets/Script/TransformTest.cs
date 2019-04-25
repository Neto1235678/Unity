using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(transform.position);
        print(transform.rotation);
        print(transform.lossyScale);

        print(transform.forward);
        print(transform.right);
        print(transform.up); // 1. 로테이션, 스케일 2. 계층 구조 표현

        print(transform == GetComponent<Transform>());
        print(transform.childCount == 3);
        print(transform.GetChild(0).name == "B");
        print(transform.GetChild(1).name == "C");
        print(transform.GetChild(0).parent.name == "A");
        print(transform.Find("D").name == "D");
        print(transform.Find("D/E").name == "E");
        print(transform.Find("D/E").root.name == "A");
        print(transform.Find("D/E").root == transform);
        print(transform.Find("D/E").root.name == transform.name);
        print(transform.Find("D/E").root.name == transform.gameObject.name);

        GetComponent<MeshRenderer>().material.color = Color.yellow;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;



        //BLS 
        //각각의 트렌스레이더,, 두번 째 파라 고려

    }
}
