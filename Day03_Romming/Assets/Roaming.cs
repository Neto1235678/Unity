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
        transform.Rotate(Vector3.up * Vector3.SignedAngle(transform.forward, dir, Vector3.up) * 10f * Time.deltaTime);
        transform.position = transform.position + dir.normalized * speed * Time.deltaTime;
      
    }
}
