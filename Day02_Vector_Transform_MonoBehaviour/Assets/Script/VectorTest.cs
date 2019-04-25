using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Vector3 v = new Vector3(1f, 1f, 1f);
        Vector3 u = new Vector3(1f, 1f, 1f);
        print(v == u);
        print(2 * v == new Vector3(2f, 2f, 2f));
        v = new Vector3(1f, 0f, 0f);
        print(v == Vector3.right);
        print(v.magnitude == 1f);
        print(Vector3.one.magnitude);
        print(v.ToString() == "1.0, 0.0, 0.0");
        print(v);
        print(Vector3.Distance(Vector3.zero, u) == u.magnitude); // Distance는 좌표점으로 봐라
        print(Vector3.Angle(Vector3.right, Vector3.up) == 90f); // 두 백터 사이의 거리
        print(Vector3.Angle(Vector3.right, Vector3.forward) == 90f);
        print((2 * Vector3.up).normalized == Vector3.up);
        print((2 * Vector3.up) / (2 * Vector3.up).magnitude == Vector3.up);
        print((2 * Vector3.up) / (2 * Vector3.up).magnitude == (2 * Vector3.up).normalized);
        print(Vector3.Cross(Vector3.right, Vector3.up) == Vector3.forward);
        print(Vector3.Cross(Vector3.up, Vector3.right) == -Vector3.forward);
        print(Vector3.Dot(Vector3.right, Vector3.up) == 1f);
        print(Vector3.Dot(Vector3.up, Vector3.right) == 1f);

        transform.position = new Vector3(5f, 0, 0);

    }
}
