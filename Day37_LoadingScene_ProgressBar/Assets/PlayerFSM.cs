using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public float moveSpeed = 4f;

    public enum State { Entry = -1, idle, Walk, Attack }
    public State state = State.idle;
    public State preState = State.Entry;

    Animator anim;
    float lastX, lastY;

    public void SetState(State state)
    {
        preState = this.state;
        this.state = state;
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
        DontDestroyOnLoad(this);
    }

    //IEnumerator Start() // 이게 한 프레임 단위로
    //{
    //    while(true)
    //    {
    //        anim.SetInteger("State", (int)state);
    //        anim.SetInteger("PrevState", (int)preState);

    //        switch(state)
    //        {
    //            case State.idle:
    //            case State.Walk:
    //                yield return StartCoroutine(Move());
    //                break;
    //            case State.Attack:
    //                yield return new WaitForSeconds(0.417f);
    //                SetState(State.idle);
    //                break;

    //                // 디폴트 값은 MS에서 쓰지 않는 것이 권고사항
    //        }
    //        yield return null;
    //    }
    //}



    IEnumerator Start() // 이게 한 프레임 단위로
    {
        while (true)
        {
            anim.SetInteger("State", (int)state);
            anim.SetInteger("PrevState", (int)preState);

            switch (state)
            {
                case State.idle:
                case State.Walk:
                    float h = Input.GetAxisRaw("Horizontal");
                    float v = Input.GetAxisRaw("Vertical");
                    Vector3 heading = new Vector3(h, v, 0).normalized;
                    Vector3 movement = heading * moveSpeed * Time.deltaTime;
                    transform.position += movement;
                    UpdtetAnimation(heading);
                    break;
                case State.Attack:
                    yield return new WaitForSeconds(0.417f);
                    SetState(State.idle);
                    break;
            }                 
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        anim.SetTrigger("OnAtt");
                        SetState(State.Attack);
                    }
            yield return null;
        }
    }

    //IEnumerator Move()
    //{
    //    while(true)
    //    {


    //        float h = Input.GetAxisRaw("Horizontal");
    //        float v = Input.GetAxisRaw("Vertical");
    //        Vector3 heading = new Vector3(h, v, 0).normalized;
    //        Vector3 movement = heading * moveSpeed * Time.deltaTime;
    //        transform.position += movement;

    //        UpdtetAnimation(heading);

    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            anim.SetTrigger("OnAtt");
    //            SetState(State.Attack);
    //            break;
    //        }
    //        anim.SetInteger("State", (int)state);
    //        anim.SetInteger("PrevState", (int)preState);

    //        yield return null;
    //    }
    //}

    private void UpdtetAnimation(Vector3 heading)
    {
        if (heading.x == 0 && heading.y == 0)
        {
            anim.SetFloat("LastDirX", lastX);
            anim.SetFloat("LastDirY", lastY);
            anim.SetBool("OnMove", false);
            SetState(State.idle);
        }
        else
        {
            lastX = heading.x;
            lastY = heading.y;
            anim.SetFloat("DirX", heading.x);
            anim.SetFloat("DirY", heading.y);
            anim.SetFloat("LastDirX", heading.x);
            anim.SetFloat("LastDirY", heading.y);
            anim.SetBool("OnMove", true);
            SetState(State.Walk);
        }


    }
}


// 트렌지션 이벤트가 발동이 되면, 실행된다.