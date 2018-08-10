﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    private static BoardView instance = null;
    private readonly int BombImageIndex = 10;

    [SerializeField]
    private Sprite[] cellSprite;

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

    public GridLayoutGroup Grid
    {
        get
        {
            return grid;
        }

        set
        {
            grid = value;
        }
    }

    public Sprite[] CellSprite
    {
        get
        {
            return cellSprite;
        }

        set
        {
            cellSprite = value;
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

    public void CreateBoard()
    {
        int boardSize = BoardController.Instance.BoardSize;
        Grid.constraintCount = boardSize;
        for (int i = 0; i < boardSize * boardSize; i++)
        {
            Instantiate(cellPrefab, Grid.transform);
        }
    }

    public void ShowCells(int r, int c, bool bombcell, int bombaround)
    {
        if (bombcell)
        {
            ShowBombImage(r, c);
            // ShowLoseNotification();
        }
        else
        {
            ShowBombAround(r, c, bombaround);
        }
    }

    private void ShowBombAround(int r, int c, int bombaround)
    {
        Cell cell = GetCellAtIndex(r, c);
        cell.SetImage(CellSprite[bombaround]);
    }

    private void ShowBombImage(int r, int c)
    {
        Cell cell = GetCellAtIndex(r, c);
        cell.SetImage(CellSprite[BombImageIndex]);
    }

    private Cell GetCellAtIndex(int r, int c)
    {
        return Grid.transform.GetChild(r * GameController.Instance.BoardSize + c).gameObject.GetComponent<Cell>();
    }

    [ContextMenu("Sort Cell Sprites by Name")]
    void SortArray()
    {
        System.Array.Sort(CellSprite, (a, b) => int.Parse(a.name).CompareTo(int.Parse(b.name)));
    }
}