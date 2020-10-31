using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(MeshRenderer))]
public class Pawn : BoardPiece, IChessPiece
{
    private PieceType _ptype;
    public PieceType ptype { get { return _ptype; } 
        set { 
        
            if(value != _ptype)
            {
                _ptype = value;
            }

        } }

    public override void InitializePiece(Color color, Coordinate spawnLoc, Action<BoardPiece> onPieceSelect)
    {
         pieceName = "Pawn";
         ptype = PieceType.CHESS_PAWN;
        base.InitializePiece(color, spawnLoc, onPieceSelect);
    }


    public override List<Coordinate> getMovement()
    {
        if (movement_coordinates == null || movement_coordinates.Count ==0)
        {
            movement_coordinates = new List<Coordinate>();
            for (int offset = 1; offset < 3; offset++)
            {
                var coordinate = new Coordinate();
                coordinate.X = currentCoordinate.X;
                coordinate.Y = currentCoordinate.Y + offset;
                movement_coordinates.Add(coordinate);
            }
        }

     
        return this.movement_coordinates;
    } 


}
