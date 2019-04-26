using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMove : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(-Vector3.left * Speed * Time.deltaTime);


    }
}
