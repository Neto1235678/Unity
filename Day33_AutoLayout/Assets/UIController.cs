using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public InputField inputField;
    public ChatSystem chatSystem;

    int uiTimeStamp = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener((message) =>
        {
            GameDateManager.Instance?.AddMessage(message, UnityEngine.Random.Range(0, 2) == 0 ? true : false);
            inputField.Select();
            inputField.ActivateInputField();
            inputField.text = string.Empty;
        });
    }

    // Update is called once per frame
    void Update()
    {
        int timeStamp = GameDateManager.Instance.GetTimeStamp();
        if (timeStamp != uiTimeStamp)
        {
            uiTimeStamp = timeStamp;
            List<ChatDate> messages = GameDateManager.Instance.GetChatData();
            chatSystem.UpdateChatData(messages);
        }
    }
}
