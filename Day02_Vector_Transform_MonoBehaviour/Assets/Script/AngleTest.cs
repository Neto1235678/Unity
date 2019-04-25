using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTest : MonoBehaviour
{

    public float Angle;
    public float RotationTime;
    float TimeCheck;
    float temp;
    bool isRotation = false;

    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        float RotationCh = Angle / RotationTime;
        float frme = Time.deltaTime;
        print(frme);
        temp = RotationCh * Time.deltaTime;
        TimeCheck += Time.deltaTime;

        if (RotationTime >= TimeCheck)
      
            transform.Rotate(Vector3.up, temp, Space.World);


        if (Input.GetKeyDown(KeyCode.Space) && !isRotation)
        {
            isRotation = true;                   
        }






     
      

        






    }
}
