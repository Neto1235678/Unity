using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NameText : MonoBehaviour
{
    Text nametext;
    int temp;

    // Start is called before the first frame update
    void Start()
    {
        nametext = GetComponent<Text>();
        Gun go = GameObject.Find("ColtM4").GetComponent<Gun>();
        temp = go.count;
    }

    // Update is called once per frame
    void Update()
    {

        nametext.text = "30 / " + temp;
    }
}
