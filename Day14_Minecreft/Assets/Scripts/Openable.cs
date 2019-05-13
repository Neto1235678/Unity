using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{


    Animator anim;
    bool isOpen = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        anim.SetBool("IsOpen", isOpen);
    }
}


// 마크 걷기 만들기.  트랜지션 스피드로