using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChMove : MonoBehaviour
{

    Rigidbody rb;
    bool toggle = false;
    public GameObject gob;
    public float Speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // 비용이 있는 함수. 그렇기에 시작 전에 담아서 사용
    }


    private void FixedUpdate() // 물리 시뮬레이션은 Fixed에 넣어야된다. 가변적으로 바뀌면 물리 시뮬레이션도 가변적이다.
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (toggle == false)
            {
                toggle = true;
            }
            else
            {
                toggle = false;
            }

            if (toggle == true)
            {
                transform.parent = null;
                rb.AddForce(new Vector3(150f, 600f, 0f) );
                rb.isKinematic = false;
            }
        }
        


        //if (transform.)
        
            
    }
}
