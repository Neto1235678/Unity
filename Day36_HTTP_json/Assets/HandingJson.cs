using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HandingJson : MonoBehaviour
{

    string pathJosn;

    // Start is called before the first frame update
    void Start()
    {
        pathJosn = Application.persistentDataPath + "/gameSense.json";
        print(pathJosn);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveJsonFile();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadJsonFile();
        }
    }

    private void LoadJsonFile()
    {
        if(File.Exists(pathJosn))
        {
            string dataAsJson = File.ReadAllText(pathJosn);
            GameScore newGS = JsonUtility.FromJson<GameScore>(dataAsJson);
            print(newGS);
        }
        else
        {
            print("no File");
        }
    }

    private void SaveJsonFile()
    {
        GameScore gs = new GameScore();
        gs.level = 10;
        gs.timeElapsed = 300;
        gs.playerName = "dga";
        gs.dontCare = "dontcare";


        Item item = new Item();
        item.itemID = 1000;
        item.iconlmage = "image1.png";
        item.price = 10000;
        gs.items = new List<Item>();
        gs.items.Add(item);

        Item item1 = new Item();
        item1.itemID = 1000;
        item1.iconlmage = "image1.png";
        item1.price = 10000;
        gs.items.Add(item1);

        string dataAsJson = JsonUtility.ToJson(gs, true);
        print(dataAsJson);
        File.WriteAllText(pathJosn, dataAsJson); // 씽크방식 블락
    }
}

[Serializable]
public class GameScore
{
    public int level;
    public float timeElapsed;
    public string playerName;

    [NonSerialized]
    public string dontCare;

    public List<Item> items;

    public override string ToString()
    {
        return level + ", " + timeElapsed + ", " + playerName + ", " + items.Count;
    }
}


[Serializable]
public class Item
{
    public int itemID;
    public string iconlmage;
    public int price;
}
// List
