﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hithithit : MonoBehaviour
{
    public GameObject smoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject fx = Instantiate(smoke, transform.position, Quaternion.identity);
        Destroy(fx, 1.5f);

    }
}
