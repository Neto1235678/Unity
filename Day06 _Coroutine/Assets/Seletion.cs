using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seletion : MonoBehaviour
{
    public float angle = 90f;
    public float duration = 1f;

    bool isRotating = false;
    float remainingAngle;
    float remainingDuration;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine(SeletionIn());
        }

    }

   IEnumerator SeletionIn()
    {

        isRotating = true;
        remainingAngle = angle;
        remainingDuration = duration;
        yield return StartCoroutine(TestIn());
    }

    IEnumerator TestIn()
    {
        if (isRotating)
        {
            float anglePerFrame = (remainingAngle / remainingDuration) * Time.deltaTime;
            for (float f = remainingAngle; f >= anglePerFrame; f -= anglePerFrame)
            {
                if (remainingAngle < anglePerFrame)
                {
                    anglePerFrame = remainingAngle;
                    isRotating = false;
                }

                transform.Rotate(Vector3.up * anglePerFrame);

                remainingAngle -= anglePerFrame;
                remainingDuration -= Time.deltaTime;

                yield return null;
            }
        }
    }
}
