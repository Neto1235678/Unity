using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHitReaction : MonoBehaviour
{
    public GameObject hitFXPrefab;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Hurt(int damage, Vector3 hitPoint, Vector3 hitMormal, Vector3 hitDorection)
    {
       GetComponent<Health>().DecreaseHP(damage);
        GameObject fx = Instantiate(hitFXPrefab, hitPoint, Quaternion.identity);
        Destroy(fx, 1.5f);


        //2
        //rb?.AddForce(hitDorection * 5f, ForceMode.VelocityChange);


        //1
        if (rb != null)
            rb.velocity += hitDorection;
        // 1, 2의 두 코드가 값이 동일하지 않다.
    }

}
