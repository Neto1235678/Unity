using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 4f;

    Animator anim;
    float lastX, lastY;
    int count = 0; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 heading = new Vector3(h, v, 0).normalized;
        Vector3 movement = heading * moveSpeed * Time.deltaTime;
        transform.position += movement;
        UpdtetAnimation(heading);
    }

    private void UpdtetAnimation(Vector3 heading)
    {
        if (heading.x == 0 && heading.y == 0)
        {
            anim.SetFloat("LastDirX", lastX);
            anim.SetFloat("LastDirY", lastY);
            anim.SetBool("Movement", false);
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Att", true);
     
            }
            else
            {
                anim.SetBool("Att", false);
            }

        }
        else
        {
            lastX = heading.x;
            lastY = heading.y;
            anim.SetBool("Movement", true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Att", true);
                anim.SetFloat("LastDirX", lastX);
                anim.SetFloat("LastDirY", lastY);

                if (count < 4)
                {
                    count++;
                    anim.SetInteger("AttCount", count);

                    if (count == 4)
                    {
                        count = 0;
                        moveSpeed = 0f;
                        anim.SetInteger("iDleRest", 3);
                        StartCoroutine(SpeedReset());
                    }                          
                }
            }
            else
            {
                anim.SetBool("Att", false);
            }
        }
        anim.SetFloat("DirX", heading.x);
        anim.SetFloat("DirY", heading.y);

        print(count);
    }

    IEnumerator SpeedReset()
    {
        yield return new WaitForSeconds(1f);
        moveSpeed = 4f;

    }
}


//칼질하는 모션 넣기.
            
            //if(Input.GetKeyDown(KeyCode.Space))
            //{
            //    anim.SetBool("Att", true);
            //}
            //else
            //{
            //    anim.SetBool("Att", false);
            //}