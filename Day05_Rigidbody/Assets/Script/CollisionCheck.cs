using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) // On ~ 어떤 상황에
    {

        // 충돌은 쌍방이다. 가해자/피해자 항상 존재한다!

        
        // OnCollisionX() 발생 조건(물리적 반응 o)
        // 1. 두 개의 gameobject 모두 collider component가 존재해야 한다.
        // 2. 둘 중 하나는 rigidbody component가 있어야된다.
        // 3. rigidbody를 가진 gameObject가 움직여 충돌되었을 때 발생한다. 그 반대는 발생하지 않는다.(예측 불가)

        print("OnCollisionEnter : " + collision.gameObject.name);
        foreach(ContactPoint contact in collision.contacts) // collison.contacts Array형태로 가지고 있기 때문에 foreach 사용가능.
        {
            Debug.DrawRay(contact.point, contact.normal, Color.magenta, 5f); // contact.normal 충돌지면의 노멀방향.
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        print("OnCollisionStay : " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        print("OnCollisionExit : " + collision.gameObject.name);
    }


    // 게임에서 아이템 혹은 보물상자 먹을 때 나오는 트리거(물리적 반응 x)
    // 1. 두 개의 gameObject 모두 collider component가 존재해야 한다.
    // 2. 둘 중 하나는 rigidbody component가 있어야 한다.(시뮬레이션 담당)
    // 3. 둘 중 하나는 collider component에 ls Trigger가 ON 되어야 한다.
    // 4. 그리고 어느 쪽이 움직이더라도 서로 만나면 이벤트가 발생한다.
    // 5. OnTriggerEnter 발생 시 OnCollisionEnter가 발생하지 않는다.

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter: " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        print("OnTriggerStay: " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit: " + other.gameObject.name);
    }
}
