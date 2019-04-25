using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointChildren : MonoBehaviour
{

    public Transform WayPoint;
    public List<Transform> wayPointList;
    public Vector3 Character;
    public Transform CharacterGameobject;
    //public Material FirstMaterial;


    // Start is called before the first frame update
    void Start()
    {
        wayPointList = new List<Transform>();
        foreach (Transform t in WayPoint)
        wayPointList.Add(t);
        print(wayPointList.Count == 8);
    }

    // Update is called once per frame
    void Update()
    {

        Character = new Vector3(CharacterGameobject.position.x, CharacterGameobject.position.y, CharacterGameobject.position.z);
            
                if(WayPoint.position.z < Character.z )
                wayPointList[0].GetComponent<MeshRenderer>().material.color = Color.yellow;
                if(wayPointList[1].position.x > Character.x)
                wayPointList[1].GetComponent<MeshRenderer>().material.color = Color.yellow;
                wayPointList[0].GetComponent<MeshRenderer>().material.color = Color.black;





    }


}
