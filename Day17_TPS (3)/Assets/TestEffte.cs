using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffte : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject.Find("BattleAxe").transform.Find("AxeTralPacticleSystem").gameObject.SetActive(true);
    }


}
