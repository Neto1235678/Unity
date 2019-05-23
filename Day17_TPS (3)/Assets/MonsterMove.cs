using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Transform target;
    Animator anim;
    Vector3 setposition;
    Vector3 getposition;
    Vector3 direction;
    Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        setposition = new Vector3(transform.localPosition.x, 
                                  transform.localPosition.y, 
                                  transform.localPosition.z);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        getposition = new Vector3(transform.localPosition.x, 
                                  transform.localPosition.y, 
                                  transform.localPosition.z);

        float dir = Vector3.Distance(target.position, transform.position);


        if (dir <= 8f)
        {
            transform.Translate(Vector3.forward * 2f * Time.deltaTime);
            transform.LookAt(target);
            anim.SetTrigger("OnMove");

        }

        if (dir <= 5f)
        {
            
            anim.SetTrigger("OnAttack");

        }

        else
        {

            transform.position = Vector3.Lerp(getposition, setposition, Time.deltaTime * 10.0f);
            anim.SetBool("OnMove", false);
            anim.SetTrigger("OnRun");
            if (transform.position == setposition)
            {
                transform.rotation = Quaternion.identity;
            }
        }
    }


}
