using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    Camera fpsCamera;


    // Start is called before the first frame update
    void Start()
    {
        fpsCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position,
                                fpsCamera.transform.forward,
                                out hit,
                                10f))
            {
                if(hit.transform.CompareTag("Block"))
                {
                    hit.transform.GetComponent<BreakUp>().Hit();
                }
            }
        }
    }
}
