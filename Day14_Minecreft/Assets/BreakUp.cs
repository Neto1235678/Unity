using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakUp : MonoBehaviour
{
    public Texture[] cracks;
    public ParticleSystem fx;

    Renderer render;
    int numHits = 0;
    float lastHitTime;
    float hitTimeThreadhold = 0.05f;


    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        lastHitTime = Time.time;
    }

    public void Hit()
    {
        CancelInvoke();
        if (Time.time > lastHitTime + hitTimeThreadhold)
        {
            numHits++;
            if (numHits < cracks.Length)
                render.material.SetTexture("_DetailMask", cracks[numHits]);
            else
            {
                var clone = Instantiate(fx, transform.position, Camera.main.transform.rotation);
                Destroy(clone, 2f); // Destroy 2가지 기능, 컴포넌트 지우기(this.name), 게임오브젝트 지우기
                Destroy(gameObject);
            }
            lastHitTime = Time.time;
        }
        Invoke("Heal", 2f);
    }
    void Heal()
    {
        numHits = 0;
        render.material.SetTexture("_DetailMask", cracks[0]);
    }
}

// 코루틴으로 짜기