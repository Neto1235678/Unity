using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcikUpobject : MonoBehaviour
{

    public Transform holder;

    Camera fpsCamera;

    // Start is called before the first frame update
    void Start()
    {
        fpsCamera = GetComponentInChildren<Camera>(); // 순서로 결정이 된다. 만약에 아니라면 퍼블릭으로 지정해서 사용.
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 4f))
            {
                print(hit.transform.name);
                var item = hit.transform.GetComponent<Pickable>();
                if(item != null)
                {
                    Pickup(hit.transform);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
            ThrowItem();
    }

    private void ThrowItem()
    {
        if(holder.childCount == 1)
        {
            Transform item = holder.GetChild(0);
            item.SetParent(null);
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().AddForce(fpsCamera.transform.forward * 700f);
        }
    }

    private void Pickup(Transform item)
    {
        if (holder.childCount == 0)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            // or item.parent = holder;
            item.SetParent(holder);
            // or item.transform.position = holder.transform.position;
            item.transform.localPosition = Vector3.zero;
        }
    }
}
