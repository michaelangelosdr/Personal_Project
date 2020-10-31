using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class BoardManager : MonoBehaviour
{

    [SerializeField] public GridSystem gridSystem = null;
    [SerializeField] public BoardPieceConfig boardConfig = null;
    [SerializeField] public BoardPiece currentSelected = null;

    private List<Coordinate> curr_highlighted_coordinates;
    public event EventHandler<BoardPiece> onPieceSelect;

    private void Awake()
    {
       if(gridSystem == null)
        {
            gridSystem = GetComponent<GridSystem>();
        }
    }

    private void Start()
    {
        gridSystem.CreateGrid();

       
        StartCoroutine(boardConfig.SpawnBoardPieces(NotifyBoard,() => {
            Debug.Log("DONE");
        }));

    }


    public void NotifyBoard(BoardPiece piece)
    {
        var gridconfig = gridSystem.currentConfig;
        if (curr_highlighted_coordinates == null)
        curr_highlighted_coordinates = new List<Coordinate>();
        else
        {
            foreach(Coordinate c in curr_highlighted_coordinates)
            {
                gridconfig.currentGrid[c.X, c.Y].SetColor(gridconfig.currentGrid[c.X,c.Y].initialColor);
            }
        }

        
        foreach(Coordinate n in piece.getMovement())
        {
            gridconfig.currentGrid[n.X, n.Y].SetColor(Color.blue);
            curr_highlighted_coordinates.Add(n);
        }
    }

}
