using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float rspeed = 200f;
        
        float h = Input.GetAxisRaw("Horizontal");

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.right * rspeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.left * rspeed * Time.deltaTime);
        

    }
}
