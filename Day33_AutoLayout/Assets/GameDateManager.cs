using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChatDate
{
    public string Message { get; set; }
    public bool IsAlignLeft { get; set; }
}

public class GameDateManager : Singleton<GameDateManager>
{
    protected GameDateManager() { }

    List<ChatDate> messages = new List<ChatDate>();
    int timeStamp = 0;

    public void AddMessage(string message, bool isAlignLeft)
    {
        if (message.Length > 0)
        {
            ChatDate msg = new ChatDate();
            msg.Message = message;
            msg.IsAlignLeft = isAlignLeft;
            messages.Add(msg);
            UpdateTimeStamp();

        }
    }

    private void UpdateTimeStamp()
    {
        timeStamp++;
        if (timeStamp <= 0)
            timeStamp = 1;
    }


    public int GetTimeStamp()
    {
        return timeStamp;
    }

    public List<ChatDate> GetChatData()
    {
        return messages;
    }
}


// 컨트롤러 - 입력박기 및 값 갱신 그리기등 진짜 컨트롤 부분
// 뷰 - 그려주는 용도