﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{

    public GameObject playerPrefab;
    public RectTransform progressBar;

    static public GameFlow instance;

    public GameObject player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneMgr.instance.OnBeginLoad += OnBeginLoad;
        SceneMgr.instance.OnLoadCompleted += OnLoadCompleted;
        SceneMgr.instance.OnProgress += OnProgress;
        SceneMgr.instance.LoadScene("Scene1");
    }

    private void OnProgress(float progress)
    {
        print("progress: " + progress);
        progressBar.GetComponent<Image>().fillAmount = progress;
    }

    private void OnLoadCompleted()
    {
        print("OnLoadCompleted");
        if(player == null)
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        progressBar.parent.gameObject.SetActive(false);
    }

    private void OnBeginLoad()
    {
        print("OnBeginLoad");
        progressBar.parent.gameObject.SetActive(true);
    }

    public void InstantiatePlayer()
    {

    }
}
