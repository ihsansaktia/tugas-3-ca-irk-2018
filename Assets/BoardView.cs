﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    private static BoardView instance = null;

    [SerializeField]
    private Transform cellPrefab;
    [SerializeField]
    private GridLayoutGroup grid;

    public static BoardView Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBoard(int boardSize)
    {
        grid.constraintCount = boardSize;
        for (int i = 0; i < boardSize * boardSize; i++)
        {
            Instantiate(cellPrefab, grid.transform);
        }
    }
}