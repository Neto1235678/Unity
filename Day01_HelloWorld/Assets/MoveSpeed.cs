using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float speed = 10f;
        float rspeed = 90f;
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //Vector3 dir = new Vector3(0, 0, v);
        //dir = dir.normalized;
        //transform.Translate(dir * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * rspeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rspeed * Time.deltaTime);

    }
}
