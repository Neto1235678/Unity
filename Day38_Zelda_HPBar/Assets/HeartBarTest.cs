using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBarTest : MonoBehaviour
{

    public Button takeDamgeButton;
    public Button healButton;
    public HeartBar bar;

    private void Awake()
    {
        takeDamgeButton.onClick.AddListener(() =>
        {
            bar.decreaseHP(5);
        });

        healButton.onClick.AddListener(() =>
        {
            bar.lncreaseHP(5);
        });
    }
}
