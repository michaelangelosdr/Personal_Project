using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "Board piece Config", menuName ="Common/Piece/Config")]
public class BoardPieceConfig : ScriptableObject
{
    [SerializeField] public List<BoardConfig> pieces;

    [SerializeField] public List<BoardPiece> currentGamePieces;

    public IEnumerator SpawnBoardPieces(Action<BoardPiece> onPieceSelect, UnityAction action)
    {
       currentGamePieces = new List<BoardPiece>();
        foreach (BoardConfig o in pieces)
        {
            var piece = GameObject.Instantiate(o.boardPiece, new Vector3(o.X, 2, o.Y), Quaternion.identity);
             piece.InitializePiece(Color.red, new Coordinate() { X = o.X, Y = o.Y },  onPieceSelect);
             piece.gameObject.name = piece.pieceName;
             currentGamePieces.Add(piece);
        }

        action?.Invoke();
        yield return null;
    }

    public void ResetGamePieces()
    {
        currentGamePieces = null;
    }
}


[Serializable]
public struct BoardConfig
{
    public BoardPiece boardPiece;
    public int X;
    public int Y;
}
