using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectorTest : MonoBehaviour
{
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(StartPs());

    }

    IEnumerator StartPs()
    {
        yield return new WaitForSeconds(1f);
        var ve1 = ps.velocityOverLifetime;
        ve1.orbitalY =  -5f;
        ve1.speedModifier = 2f;
        yield return new WaitForSeconds(1f);
        ve1.orbitalY = 0f;
        ve1.speedModifier = 1f;
        yield return null;
    }
}
