using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float speed = 200f;

        if (Input.GetKey(KeyCode.W))
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.S))
            transform.Rotate(-Vector3.right * speed * Time.deltaTime);
        
    }
}
