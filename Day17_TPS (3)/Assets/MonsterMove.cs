using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MoveState
{
    Attack,
    Move,
    iDle
}

public class MonsterMove : MonoBehaviour
{
    public Transform target;
    Animator anim;
    Vector3 setposition;
    Vector3 getposition;
    Vector3 direction;
    Rigidbody rb;
    float dir;
    public MoveState state = MoveState.iDle;

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
        dir = Vector3.Distance(target.position, transform.position);

        StateCheck();
    
    }


    void Move()
    {
        state = MoveState.Move;                
    }

    void iDle()
    {
        state = MoveState.iDle;
    }

    void Attack()
    {
        state = MoveState.Attack;
        
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
        Move();
    }

    void StateCheck()
    {
        switch(state)
        {
            case MoveState.iDle:
                if(dir > 10)
                {
                    transform.position = Vector3.Lerp(getposition, setposition, Time.deltaTime * 10.0f);
                    anim.SetTrigger("OniDle");
                    anim.SetBool("OnRun", false);
                    anim.SetBool("OnAttack", false);
                    if (transform.position == setposition)
                    {
                        transform.rotation = Quaternion.identity;
                    }
                }
                else
                {
                    Move();
                }
                break;

            case MoveState.Move:
                if (dir < 10)
                {
                    transform.Translate(Vector3.forward * 2f * Time.deltaTime);
                    transform.LookAt(target);
                    anim.SetTrigger("OnRun");
                    anim.SetBool("OnAttack", false);
                }
                else
                {
                    iDle();
                }

                if(dir < 2)
                {
                    Attack();
                }
                break;

            case MoveState.Attack:
                if (dir < 2)
                {
                    anim.SetTrigger("OnAttack");
                    anim.SetBool("OnRun", false);
                }
                if (dir > 4 && dir < 8)
                {
                    StartCoroutine(Test());
                    
                }
                if (dir > 10)
                {
                    iDle();
                }

                break;

        }
    }
}
