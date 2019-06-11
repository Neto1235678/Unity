using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{

    public Health leftSide;
    public Health rightSide;

    public Button ldamageButton;
    public Button lhealButton;
    public Button rdamageButton;
    public Button rhealButton;

    public Text timerText;

    int uiTimeStamp = 0;
    int timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        ldamageButton.onClick.AddListener(() => GameDataManager.Instance.TakeDamage(10));
        lhealButton.onClick.AddListener(() => GameDataManager.Instance.Heal(20));

        rdamageButton.onClick.AddListener(() => GameDataManager.Instance.TakeDamage(10));
        rhealButton.onClick.AddListener(() => GameDataManager.Instance.Heal(20));
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp = GameDataManager.Instance.GetTimeStemp();

        if (timeStamp != uiTimeStamp)
        {
            uiTimeStamp = timeStamp;

            if (rdamageButton)
            {
                RButtonDamage();
            }
            else if(rhealButton)
            {
                RButtonHealth();
            }

            else if (ldamageButton)
            {
                LButtonDamage();
            }
            else if (lhealButton)
            {
                LButtonHealth();
            }

        }
    }

    protected void LButtonDamage()
    {

          
            float currentHealth = GameDataManager.Instance.GetCurrnetHeath();
            float maxHealth = GameDataManager.Instance.GetMaxHeath();
            leftSide.UpdateHealthBar(currentHealth, maxHealth);
        
    }

    protected void LButtonHealth()
    {
  
            
            float currentHealth = GameDataManager.Instance.GetCurrnetHeath();
            float maxHealth = GameDataManager.Instance.GetMaxHeath();
            leftSide.UpdateHealthBar(currentHealth, maxHealth);
        
    }

    protected void RButtonDamage()
    {


     
            float currentHealth = GameDataManager.Instance.GetCurrnetHeath();
            float maxHealth = GameDataManager.Instance.GetMaxHeath();
            rightSide.UpdateHealthBar(currentHealth, maxHealth);
        
    }

    protected void RButtonHealth()
    {
 
          
            float currentHealth = GameDataManager.Instance.GetCurrnetHeath();
            float maxHealth = GameDataManager.Instance.GetMaxHeath();
            rightSide.UpdateHealthBar(currentHealth, maxHealth);
        
    }
}
