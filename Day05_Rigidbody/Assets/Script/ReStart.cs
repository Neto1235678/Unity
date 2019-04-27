using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{

    public Transform listgameobject;

    private void Start()
    {



        
    }


    // Update is called once per frame
    private void Update()
    {



        if(listgameobject.childCount == 0)
        {
            SceneManager.LoadScene("HW0426");
        }

    }
}
