using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private void OnEnable()
    {
        print("OnEnable");
    }

    private void OnDisable()
    {
        print("OnDisable");
    }
}

// Rigibody 초기화는 벨로시티 값을 초기화 하지 않을 시 이상하게되고
// Pool 초기화는 OnEnable, OnDisalble에서 한다.
// 탄피 넣기