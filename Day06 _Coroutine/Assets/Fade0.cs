﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade0 : MonoBehaviour
{

    bool fadeln = false;
    float alpha = 1.0f;
    MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !fadeln)
        {
            fadeln = true;
            alpha = 1.0f;
        }
        if(fadeln && alpha > 0f)
        {
            Color c = renderer.material.color;
            alpha -= 0.01f;
            if(alpha < 0f)
            {
                alpha = 0f;
                fadeln = false;
            }
            c.a = alpha;
            renderer.material.color = c;
        }
    }
}
