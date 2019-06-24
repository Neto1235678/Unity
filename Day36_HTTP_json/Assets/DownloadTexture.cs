using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTextureFromURL());
    }

    IEnumerator GetTextureFromURL()
    {
        string url = "https://avatars1.githubusercontent.com/u/49966634?s=460&v=4";



        // 1
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url)) // using 후 쓰면 알아서 dispose(); 를 해준다. http는 비암호화 https는 암호화
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                print(uwr.error);
            }
            else
            {
                var textuer = DownloadHandlerTexture.GetContent(uwr);
                GetComponent<Renderer>().material.mainTexture = textuer;
            }
        }


        // 1-1
        //{
        //    UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        //    try
        //    {
        //        yield return uwr.SendWebRequest();
        //        if (uwr.isNetworkError || uwr.isHttpError)
        //        {
        //            print(uwr.error);
        //        }
        //        else
        //        {
        //            var textuer = DownloadHandlerTexture.GetContent(uwr);
        //            GetComponent<Renderer>().material.mainTexture = textuer;
        //        }
        //    }
        //    finally
        //    {
        //        if (uwr != null)
        //        {
        //            uwr.Dispose(); // 실행이 되던 안되던 실행, 반납해라.
        //        }
        //    }
        //}


        //2
        //using (WWW www = new WWW(url))
        //{
        //    yield return www;
        //    GetComponent<Renderer>().material.mainTexture = www.texture;
        //}
    }
}

// Json으로 로드되게