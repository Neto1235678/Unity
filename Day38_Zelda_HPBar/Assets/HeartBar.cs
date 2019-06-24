using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Heart
{
    public Image foregroundImage;
    public Image[] glowImage;
    public RectTransform glow;

    public Heart(int maxHealth)
    {
        glowImage = new Image[maxHealth];
    }

    public void TurnOffAllGlow()
    {
        for (int i = 0; i < glowImage.Length; i++)
            TurnOffGlowAt(i);
    }

    public void TurnOffGlowAt(int i)
    {
        glowImage[i].enabled = false;
        glowImage[i].fillAmount = 0;
    }

    public void TurnOnGlowAt(int i)
    {
        glowImage[i].enabled = true;
        glowImage[i].fillAmount = 1;
    }
}
//public Heart(int maxHealth)
//{ 
//    glowImage = new Image[maxHealth];
//}

//public void TurnOnGlowAt(int j)
//{

//}

public class HeartBar : MonoBehaviour
{
    public GameObject heartPrefab;

    public int totalHealth;
    public int CurrentHealth { get; private set; }
    const int healthPerHeart = 4;

    List<Heart> list;
    private Coroutine coAnimDecreaseHP;
    private int previousAmout;
    private bool isAfterDecHP;

    private void Awake()
    {
        list = new List<Heart>();
        CurrentHealth = totalHealth;
        int remainHealth = totalHealth;
        while(remainHealth > 0)
        {
            if(remainHealth < healthPerHeart)
                list.Add(new Heart(remainHealth));
            else
                list.Add(new Heart(healthPerHeart));
            remainHealth -= healthPerHeart;
        }
        foreach(var h in list)
        {
            var clone = Instantiate(heartPrefab, transform);
            h.foregroundImage = clone.transform.Find("Background/Foreground").GetComponent<Image>();
            h.glow = (RectTransform)clone.transform.Find("Glow");
            for(int i = 0; i < h.glowImage.Length; i++)
            {
                h.glowImage[i] = h.glow.GetChild(i).GetComponent<Image>();
            }
            h.TurnOffAllGlow();
        }
        FillALLHearts();
    }

    private void FillALLHearts()
    {
        int i = 0;
        foreach(var h in list)
        {
            int heartIndex = i / healthPerHeart;
            int currentHeartIndex = CurrentHealth / healthPerHeart;
            if(heartIndex < currentHeartIndex)
            {
                h.foregroundImage.fillAmount = 1f;
            }
            else if(heartIndex == currentHeartIndex)
            {
                //h.foregroundImage.fillAmount = (float)(CurrentHealth & healthPerHeart) / healthPerHeart;
                h.foregroundImage.fillAmount = (float)(CurrentHealth - i) / healthPerHeart;
            }
            else if(heartIndex > currentHeartIndex)
            {
                h.foregroundImage.fillAmount = 0f;
            }


            i += healthPerHeart;
        }
    }

    public void decreaseHP(int amout)
    {
        
        StopAnim(previousAmout);
        previousAmout = amout;
        coAnimDecreaseHP = StartCoroutine(AnimDescreaseHP(amout));
    }

    private void StopAnim(int previousAmout)
    {
        if (coAnimDecreaseHP != null)
        {
            if (!isAfterDecHP)
                DecHP(previousAmout);
            foreach (var h in list)
                h.TurnOffAllGlow();
            FillALLHearts();
            StopCoroutine(coAnimDecreaseHP);
            coAnimDecreaseHP = null;
        }
    }

    IEnumerator AnimDescreaseHP(int amout)
    {
        if(amout <= 0 || CurrentHealth == 0)
        {
            yield break; // break쓰면 Coroutine 종료
        }
        int last = CurrentHealth - 1;
        int first = CurrentHealth - amout > 0 ? CurrentHealth - amout : 0;

        isAfterDecHP = false;
        FillGlow(first, last);
        yield return StartCoroutine(AnimGlow());
        DecHP(amout);
        isAfterDecHP = true;
        FillALLHearts();

        // anim Glow
        for(int i = last; i >= first; i--)
        {
            Image glow = GetGlowImageHearthPoint(i);
            glow.fillClockwise = false;
            float begin = 0;
            float f = 1f;
            while(f > begin)
            {
                glow.fillAmount = f;
                f -= 5f * (last - first + 1) * Time.deltaTime;
                yield return null;
            }
            glow.fillAmount = begin;
        }

    }

    private Image GetGlowImageHearthPoint(int i)
    {
        return GetHeartAtHealthPoint(i).glowImage[i % healthPerHeart];
    }

    private void DecHP(int amout)
    {
        CurrentHealth -= amout;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, totalHealth);
    }

    private void IncHP(int amout)
    {
        CurrentHealth += amout;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, totalHealth);
    }

    IEnumerator AnimGlow()
    {
        foreach(var h in list)
        {
            h.glow.localScale = Vector3.one * 1.9f;
        }
        yield return new WaitForSeconds(0.6f);
        foreach (var h in list)
        {
            h.glow.localScale = Vector3.one * 1.5f;
        }
        yield return new WaitForSeconds(0.6f);
    }

    private void FillGlow(int from, int to)
    {
        for(int i = from; i <= to; i++)
        {
            Heart h = GetHeartAtHealthPoint(i);
            h.TurnOnGlowAt(i % healthPerHeart);
        }
    }

    private Heart GetHeartAtHealthPoint(int i)
    {
        return list[i / healthPerHeart];
    }

    public void lncreaseHP(int amout)
    {
        throw new NotImplementedException();
    }

}
