using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIControllerEvent : MonoBehaviour
{

    public Health leftSide;
    public Button ldamageButton;
    public Button lhealButton;


    public Text timerText;

    int uiTimeStamp = 0;
    int timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        ldamageButton.onClick.AddListener(() => GameDataManagerEvent.Instance.TakeDamage(10));
        lhealButton.onClick.AddListener(() => GameDataManagerEvent.Instance.Heal(20));

        StartCoroutine(StartTimer());
    }

   IEnumerator StartTimer()
    {
        int timeCount = GameDataManagerEvent.Instance.GetTimeCount();
        while(timeCount >= 0)
        {
            GameDataManagerEvent.Instance.SetTimeCount(--timeCount);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnEnable()
    {
        GameDataManagerEvent.Instance.OnDataChanged += OnDataUpdate;
    }

    private void OnDisable()
    {
        if(GameDataManagerEvent.Instance != null)
        {
            GameDataManagerEvent.Instance.OnDataChanged -= OnDataUpdate;
        }
        
    }

    // Update is called once per frame
    void OnDataUpdate()
    {
        //timeStamp = GameDataManagerEvent.Instance.GetTimeStemp();

        //if (timeStamp != uiTimeStamp) // Polling
        {
            //uiTimeStamp = timeStamp;
            float currentHealth = GameDataManagerEvent.Instance.GetCurrnetHeath();
            float maxHealth = GameDataManagerEvent.Instance.GetMaxHeath();
            leftSide.UpdateHealthBar(currentHealth, maxHealth);

            int timeCount = GameDataManagerEvent.Instance.GetTimeCount();
            timerText.text = timeCount.ToString();
        }
    }

   
}
