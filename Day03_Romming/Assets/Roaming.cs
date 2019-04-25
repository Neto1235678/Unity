using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : MonoBehaviour
{

    public Transform wayPointsRoot;

    List<Transform> wayPoints;
    public float speed;
    private Vector3 nextPoint;
    public int n = 0;


    // Start is called before the first frame update
    void Start()
    {
        wayPoints = new List<Transform>();
        foreach (Transform t in wayPointsRoot)
            wayPoints.Add(t);
        nextPoint = wayPoints[n].transform.position;

        for(int i = 0; i < wayPoints.Count; i++)
            wayPoints[i].GetComponent<MeshRenderer>().material.color = Color.magenta;
        wayPoints[n].GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, nextPoint) < 0.5f)
        {
            n++;
            n %= wayPoints.Count; // 0으로 초기화
            nextPoint = wayPoints[n].transform.position;

            wayPoints[n].GetComponent<MeshRenderer>().material.color = Color.yellow;
            if(n == 0)
                wayPoints[wayPoints.Count - 1].GetComponent<MeshRenderer>().material.color = Color.magenta;
            else
                wayPoints[n - 1].GetComponent<MeshRenderer>().material.color = Color.magenta;
        }
        Vector3 dir = nextPoint - transform.position;
        dir.y = 0;
        //transform.Rotate(Vector3.up * Vector3.Angle(transform.forward, dir) * 10f * Time.deltaTime);
        //transform.Rotate(Vector3.up * Vector3.SignedAngle(transform.forward, dir, Vector3.up) * 10f * Time.deltaTime);
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir, Vector3.up), 0.15f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15f); // LookRotation : 바라보는 곳이 어디냐. foword 방향이 어디냐



        //transform.position = transform.position + dir.normalized * speed * Time.deltaTime;
        //transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //transform.position = Vector3.Lerp(transform.position, nextPoint, speed * Time.deltaTime); // 캐릭터 현재 위치에서의 거리 값.(등속x)
        //transform.position = Vector3.Lerp(transform.position, nextPoint, speed * Time.deltaTime / dir.magnitude);
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        //transform.position = Vector3.Slerp(transform.position, nextPoint, speed * Time.deltaTime);
        //transform.position = Vector3.Slerp(transform.position, nextPoint, speed * Time.deltaTime / dir.magnitude);

    }   
}
