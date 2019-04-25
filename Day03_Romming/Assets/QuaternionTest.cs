using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0f, 50f, 0f);
        print(Mathf.Approximately(transform.eulerAngles.y, 50f));

        //transform.rotation *= Quaternion.Euler(0f, 100f, 0f); // 쿼터너의 누적은 * 연산.

        transform.rotation = Quaternion.Euler(0f, 100f, 0f);
        print(Mathf.Approximately(transform.eulerAngles.y, 100f));
        transform.Rotate(Vector3.up * 90f);
        print(Mathf.Approximately(transform.eulerAngles.y, 190f));  // -170
        transform.rotation *= Quaternion.AngleAxis(90f, Vector3.up);
        print(Mathf.Approximately(transform.eulerAngles.y, 280f));  // -80


        transform.rotation = Quaternion.identity;
        print(Mathf.Approximately(transform.eulerAngles.x, 0f));
        print(Mathf.Approximately(transform.eulerAngles.y, 0f));
        print(Mathf.Approximately(transform.eulerAngles.z, 0f));
        transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
        print(Mathf.Approximately(transform.eulerAngles.x, 90f));

        transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
        print(Mathf.Approximately(transform.eulerAngles.y, 90f));
        transform.rotation = Quaternion.LookRotation(Vector3.right);
        print(Mathf.Approximately(transform.eulerAngles.y, 90f));

        Quaternion q1 = Quaternion.Euler(0f, -45f, 0f);
        Quaternion q2 = Quaternion.Euler(0f, 45f, 0f);
        print(Mathf.Approximately(Quaternion.Angle(q1, q2), 90f));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
