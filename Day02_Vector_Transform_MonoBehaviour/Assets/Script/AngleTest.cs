using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTest : MonoBehaviour
{

    public float Angle;
    public float RotationTime;
    float TimeCheck;
    float temp;
    float Test;
    bool isRotation = false;

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {


        temp = Angle / RotationTime * Time.deltaTime;
        

        TimeCheck += Time.deltaTime;

        if (RotationTime >= TimeCheck)
            transform.Rotate(Vector3.up, temp);


        if (Input.GetKeyDown(KeyCode.Space) && !isRotation)
        {
            isRotation = true;                   
        }






     
      

        






    }
}
