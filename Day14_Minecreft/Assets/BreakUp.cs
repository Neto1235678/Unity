using System;
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
        StopAllCoroutines("Heal");
        //CancelInvoke();
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
        //Invoke("Heal", 2f);
        StartCoroutine("Heal");

        
    }

    IEnumerator Heal()
    {
        numHits = 0;
        render.material.SetTexture("_DetailMask", cracks[0]);
        yield return null;
    }
}

// 코루틴으로 짜기
// 좌우키 누르면 회전, 전진하면 앞으로 후진하면 뒤로
// 우클릭하고 회전 앞으로 이동 뒤로 이동 가능 좌우 누르면 이동
// 좌클릭하면 카메라만 회전 캐릭터 둘러보게끔 움직임가능, 회전가능
// 휠 줌인 줌아웃
// 더미 몸안에, 메인은 뒤에 있다. 메인에 마우스 룩 스크립트. 로테이션 스피드. 줌 스피드. 카메라 앵글 X
// 좌클릭 더미를 돌려서 좌클릭구현
// 실행하면 메인 카메라를 위로 어느정도 올린다
// 줌인은 더미 카메라를 기준으로 로컬값으면 메인 카메라 Z 축을 땅긴다.