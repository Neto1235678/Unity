using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float speed = 10f;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 1:
        //h *= speed * Time.deltaTime; // n- 에 걸린 시간
        //v *= speed * Time.deltaTime;
        //transform.Translate(Vector3.right * h);
        //transform.Translate(Vector3.forward * v);

        // 2:

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
