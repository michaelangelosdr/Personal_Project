using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class BoardManager : MonoBehaviour
{

    [SerializeField] public GridSystem gridSystem = null;
    [SerializeField] public BoardPieceConfig boardConfig = null;

    private List<Coordinate> curr_highlighted_coordinates;
    public event EventHandler<BoardPiece> onPieceSelect;

    public bool TEST = false;
    private BoardPiece boardPiece = null;

    private void Awake()
    {
       if(gridSystem == null)
        {
            gridSystem = GetComponent<GridSystem>();
        }
    }

    private void Start()
    {
        gridSystem.CreateGrid(NotifyBoard);
  
        StartCoroutine(boardConfig.SpawnBoardPieces(NotifyBoard,() => {
            Debug.Log("DONE");
        }));

    }


    public void NotifyBoard(BoardPiece piece)
    {
        var gridconfig = gridSystem.currentConfig;

        ResetBoardColor();

        foreach (Coordinate n in piece.getMovement())
        {
            Debug.Log(n.X + "HEHE" + n.Y);
            gridconfig.currentGrid[n.X, n.Y].SetColor(Color.blue);
            curr_highlighted_coordinates.Add(n);
        }

        boardPiece = piece;

        TEST = true;
    }

    public void NotifyBoard(Grid grid)
    {
     

        if (TEST && boardPiece != null)
        {
            Debug.Log("HEHE");
         StartCoroutine(   boardPiece.Move(new Coordinate()
            {
                X = grid.X,
                Y = grid.Y
            }));

        }

        TEST = false;

        boardPiece = null;
        ResetBoardColor();

        return;
    }

    private void ResetBoardColor()
    {
        var gridconfig = gridSystem.currentConfig;
        if (curr_highlighted_coordinates == null)
            curr_highlighted_coordinates = new List<Coordinate>();
        else
        {
            foreach (Coordinate c in curr_highlighted_coordinates)
            {
                gridconfig.currentGrid[c.X, c.Y].SetColor(gridconfig.currentGrid[c.X, c.Y].initialColor);
            }
        }

    }

}
