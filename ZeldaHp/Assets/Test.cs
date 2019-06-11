using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button button;

    public Image image;
    float time = 1f;
    int count = 0;
    int i = 0;

    public List<Image> list = new List<Image>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.gameObject.tag == "Button1")
        {
            Test1();
        }

        if (Input.GetMouseButtonDown(0) && transform.gameObject.tag == "Button2")
        {
            Test2();
        }
                    
            
    }

    public void Test1()
    {

            for(i = 0; i < list.Count; i++)
            {
                if(list[i] == list[count])
                {
                    list[i].fillAmount -= 0.25f / time;

                    if (list[i].fillAmount == 0)
                    {
                        count++;
                    }
                }                                
            }           
    }

    public void Test2()
    {

            for (i = 0; i < list.Count; i++)
            {
                if (list[i] == list[count])
                {
                    list[i].fillAmount -= 0.50f / time;

                    if (list[i].fillAmount == 0)
                    {
                        count++;
                    }
                }
            }
    }
}
