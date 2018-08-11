﻿using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    
    private static readonly int MinBoard = 1;  
    private static readonly int MaxBoard = 20;  
    private static readonly int MinBomb = 1;  
    private static readonly int MaxBomb = MaxBoard * MaxBoard / 3;  

    [SerializeField]
    private int boardSize = -1;

    [SerializeField]
    private int bombs = -1;

    public static GameController Instance
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

    public int BoardSize
    {
        get
        {
            return boardSize;
        }

        set
        {
            boardSize = value;
        }
    }

    public int Bombs
    {
        get
        {
            return bombs;
        }

        set
        {
            bombs = value;
        }
    }

    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public void SetBoardSize(Text boardsize)
    {
        BoardSize = int.Parse(boardsize.text);
        EnterGame();
    }

    public void SetBombs(Text bombs)
    {
        Bombs = int.Parse(bombs.text);
        EnterGame();
    }

    public void EnterGame()
    {
        if (IsBoardSizeValid() && IsBombsValid())
        {
            EnterBoard();
        }
    }

    public bool IsBoardSizeValid()
    {
        return MinBoard <= BoardSize && BoardSize <= MaxBoard;
    }

    public bool IsBombsValid()
    {
        return MinBomb <= Bombs && Bombs <= MaxBomb;
    }

    public void ResetData()
    {
        BoardSize = -1;
        Bombs = -1;
    }

    public void BackToMainMenu()
    {
        SceneLoader.LoadScene(0);
    }

    public void EnterBoard()
    {
        SceneLoader.LoadScene(1);
    }
}
