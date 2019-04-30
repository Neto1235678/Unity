using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    bool showDialog = false;
    string answr = "";
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return StartCoroutine("ShowDialog");
        yield return StartCoroutine(answr); // 함수를 string으로 호출
    }

    // Update is called once per frame
    IEnumerator ShowDialog()
    {
        showDialog = true;
        do
        {
            yield return null;
        } while (answr == "");
        showDialog = false;
    }

    IEnumerator ActionA()
    {
        print("ActionA");
        yield return new WaitForSeconds(1f);
    }
    IEnumerator ActionB()
    {
        print("ActionB");
        yield return new WaitForSeconds(2f);
    }

    private void OnGUI()
    {
        if (showDialog)
        {
            if (GUI.Button(new Rect(10f, 10f, 100f, 20f), "A"))
            {
                answr = "ActionA";
            }
            else if (GUI.Button(new Rect(10f, 50f, 100f, 20f), "B"))
            {
                answr = "ActionB";
            }
        }
    }
}
