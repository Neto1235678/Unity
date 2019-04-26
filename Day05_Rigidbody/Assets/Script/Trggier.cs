using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trggier : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ch")

            //Application.LoadLevel("HW0426");
            SceneManager.LoadScene("HW0426");
    }

}
