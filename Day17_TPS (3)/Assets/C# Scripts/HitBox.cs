﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderState
{
    Closed,
    Open,
    Colliding
}

public interface IHitBoxResponder
{
    void collisionWith(Collider collider, HitBox hitBox);
}


public class HitBox : MonoBehaviour
{
    public LayerMask mask;
    public Collider[] hitBoxes;
    public Color inactiveColor;
    public Color collisionOpenColor;
    public Color collidngColor;
    public bool drawGizom = true;
    public bool updateInEditor = false;
    public ColliderState state = ColliderState.Closed;

    List<Collider> list;
    IHitBoxResponder reponder = null;
    Dictionary<int, int> hitObjects;

    public bool enableMultipleHits { get; set; }

    private void Awake()
    {
        list = new List<Collider>();
        hitObjects = new Dictionary<int, int>();
    }


    private void OnDrawGizmos()
    {
        if(!drawGizom)
        {
            return;
        }

        if(updateInEditor && !Application.isPlaying)
        {
            UpdateHitBox();
            //print("UpdateHitBox");
        }

        //UpdateHitBox(); 우리가 따로 불러서 써야된다. 필요한 시점에서만 사용

        CheckGizomColor();
        Gizmos.matrix = transform.localToWorldMatrix; // 기즈모.matrix를 쓸려면 월드기준에서 정의하기 때문에 로컬쪽에서 쓰는 박스들은 로컬 기준이므로 월드기준으로 바꿔줘야된다.
        foreach(var c in hitBoxes)
        {
            if (c.GetType() == typeof(BoxCollider))
            {
                BoxCollider bc = (BoxCollider)c;
                Gizmos.DrawCube(bc.center, bc.size);
            }
            //if (c.GetType() == typeof(SphereCollider))
            //{
            //    SphereCollider sc = (SphereCollider)c;
            //    Gizmos.DrawSphere(sc.center, sc.radius);
            //}
        }
    }

    public void GetContactInfo(Vector3 from, 
                                 Vector3 to, 
                                 out Vector3 hitPoint, 
                                 out Vector3 hitNormal, 
                                 out Vector3 hitDirection, 
                                 int mask, 
                                 float maxDirtance)
    {
        RaycastHit hit;
        hitPoint = to;
        hitNormal = from;
        hitNormal = hitNormal.normalized;
        hitDirection = -hitNormal;
        if (Physics.Raycast(from,
                            hitDirection,
                            out hit,
                            maxDirtance,
                            mask,
                            QueryTriggerInteraction.Collide))
        {
            hitPoint = hit.point;
            hitNormal = hit.normal;

        }


        //Debug.Log("OneHit: " + name);
        Debug.DrawLine(from, hitPoint, Color.yellow, 2f);
        Debug.DrawLine(hitPoint, hitPoint + hitNormal, Color.magenta, 2f);
        Debug.DrawLine(hitPoint, hitPoint + hitDirection, Color.cyan, 2f);
    }

    private void CheckGizomColor()
    {
       
        switch(state)
        {
            case ColliderState.Closed:
                Gizmos.color = inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = collidngColor;
                break;
        }
    }

    public void UpdateHitBox()
    {
        if (list == null)
        {
            list = new List<Collider>();
            
        }
        else
        {
            list.Clear();
        }

        if (state == ColliderState.Closed)
            return;
        foreach(var c in hitBoxes)
        {
            if (c.GetType() == typeof(BoxCollider))
            {
                BoxCollider bc = (BoxCollider)c;
                Collider[] colliders = Physics.OverlapBox(transform.TransformPoint(bc.center), 
                                                          bc.size * 0.5f, 
                                                          transform.rotation, 
                                                          mask, 
                                                          QueryTriggerInteraction.Collide); // TransformD~ 로테이션만 스케일 무시, TransfomVector3는 스케일도 포험, Point는 모든 정보(위치 로테 스케일 다)

                list.AddRange(colliders);
            }
            if (c.GetType() == typeof(SphereCollider))
            {
                SphereCollider sc = (SphereCollider)c;
                Collider[] colliders = Physics.OverlapSphere(transform.TransformPoint(sc.center), 
                                                            sc.radius, 
                                                            mask, 
                                                            QueryTriggerInteraction.Collide);

                list.AddRange(colliders);
            }
        }

        foreach (var c in list)
        {
            int id = c.transform.root.gameObject.GetInstanceID();
            if (!hitObjects.ContainsKey(id))
                hitObjects[id] = 1;
            else
            {
                hitObjects[id] += 1;
                if (!enableMultipleHits)
                    continue;
            }

            // C# 6.0
            reponder?.collisionWith(c, this);

        }

        state = list.Count > 0 ? ColliderState.Colliding : ColliderState.Open;
    }

    public void StartCheckingCollsion()
    {
        state = ColliderState.Open;
        hitObjects.Clear();
    }

    public void StopCheckingCollsion()
    {
        state = ColliderState.Closed;
    }

    public void SetResponder(IHitBoxResponder reponder)
    {
        this.reponder = reponder;
    }
}