using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{

    public string nextStage;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //transform.GetChild(0).DOLocalMoveX(-1, 1);
            //transform.GetChild(0).DOLocalMoveX(1, 1);
            SceneMgr.instance.LoadScene(nextStage);
            anim.SetBool("Open", true);
        }
    }
}
