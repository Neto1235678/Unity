using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class DownloadJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetJsonFromURL());
    }

    IEnumerator GetJsonFromURL()
    {
        // dummy sjon: https://jsonplaceholder.typicode.com
        string url = "https://jsonplaceholder.typicode.com/todos/1";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            } else
            {
                string json = www.downloadHandler.text;
                print(json);
            }
        }
    }
}
