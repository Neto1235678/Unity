using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{

    public float moveSpeed = 4f;
    Animator anim;
    float lastX, lastY;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("OnAtt");//or anim.SetBool("OnAtt", true);

        }
    }

    private void UpdtetAnimation(Vector3 heading)
    {
        if (heading.x == 0 && heading.y == 0)
        {
            anim.SetFloat("LastDirX", lastX);
            anim.SetFloat("LastDirY", lastY);
            anim.SetBool("Movement", false);


            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    anim.SetBool("Att", true);

            //}
            //else
            //{
            //    anim.SetBool("Att", false);
            //}

        }
        else
        {
            lastX = heading.x;
            lastY = heading.y;
            anim.SetFloat("DirX", heading.x);
            anim.SetFloat("DirY", heading.y);
            anim.SetFloat("LastDirX", heading.x);
            anim.SetFloat("LastDirY", heading.y);
            anim.SetBool("Movement", true);

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    anim.SetBool("Att", true);
            //    anim.SetFloat("LastDirX", lastX);
            //    anim.SetFloat("LastDirY", lastY);
            //}
            //else
            //{
            //    anim.SetBool("Att", false);
            //}
        }


    }


}
