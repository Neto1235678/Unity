using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform Parent;
    public GameObject recovery;
    public float speed;
    float Up;
    // Start is called before the first frame update
    void Start()
    {
        Parent = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        // [-1, 0, 1]
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        //print(v);

        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        transform.Translate(Vector3.right * h * speed *  Time.deltaTime);

       
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name == "stair" || collision.gameObject.name == "walk")
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            if(Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            
        }

       if(collision.gameObject.name == "recovery1")
        {
            GameObject.Instantiate(recovery, transform.position, transform.rotation).transform.parent = Parent.transform;
            if(Parent.Find("recovery(Clone)"))
            {
                //Destroy();
            }
            
            
        }
    }
}
