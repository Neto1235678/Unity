using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManagerEvent : Singleton<GameDataManagerEvent>
{
    protected GameDataManagerEvent() { }

    float currentHealth = 100;
    float maxHealth = 100;
    int timeCount = 99;

    int timeStamp = 0;

    public event Action OnDataChanged;
    int actionTimeStemp = 0;
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0f)
        {
            currentHealth = 0;
            
        }
        UpdateTimeStemp();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateTimeStemp();
    }

    public float GetCurrnetHeath()
    {
        return currentHealth;
    }

    public float GetMaxHeath()
    {
        return maxHealth;
    }

    public int GetTimeCount()
    {
        return timeCount;
    }

    public void SetTimeCount(int t)
    {
        timeCount = t;
        UpdateTimeStemp();
    }

    void UpdateTimeStemp()
    {
        timeStamp++;
        if (timeStamp <= 0)
            timeStamp = 1;
    }
    public int GetTimeStemp()
    {
        return timeStamp;
    }


    public void Update()
    {
        if(actionTimeStemp != timeStamp)
        {
            actionTimeStemp = timeStamp;
            if(OnDataChanged != null)
            {
                //or OnDataChanged();
                OnDataChanged.Invoke();
            }
        }
    }

    private void Start()
    {
        
    }
}
