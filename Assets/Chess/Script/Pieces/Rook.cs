﻿using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(MeshRenderer))]
public class Rook : BoardPiece, IChessPiece
{
    private PieceType _ptype;
    public PieceType ptype
    {
        get { return _ptype; }
        set
        {

            if (value != _ptype)
            {
                _ptype = value;
            }

        }
    }

   

    public override void InitializePiece(Color color, Coordinate spawnLoc, Action<BoardPiece> onPieceSelect)
    {
        pieceName = "Rook";
        ptype = PieceType.CHESS_ROOK;
        base.InitializePiece(color, spawnLoc, onPieceSelect);
    }


    public override List<Coordinate> getMovement()
    {
        if (movement_coordinates == null || movement_coordinates.Count == 0)
        {
            movement_coordinates = new List<Coordinate>();


            #region Up down left right
            for (int forwardOffset = 1; forwardOffset < 8 - currentCoordinate.Y; forwardOffset++)
            {
                Coordinate c = new Coordinate()
                {
                    X = currentCoordinate.X,
                    Y = currentCoordinate.Y + forwardOffset
                };
                movement_coordinates.Add(c);
            }

            for (int downOffset = 0; downOffset < currentCoordinate.Y; downOffset++)
            {
                Coordinate c = new Coordinate()
                {
                    X = currentCoordinate.X,
                    Y = downOffset
                };
                movement_coordinates.Add(c);
            }

            for (int rightOffset = 1; rightOffset < 8 - currentCoordinate.X; rightOffset++)
            {
                Coordinate c = new Coordinate()
                {
                    X = currentCoordinate.X + rightOffset,
                    Y = currentCoordinate.Y
                };
                movement_coordinates.Add(c);
            }

            for (int leftOffset = 0; leftOffset < currentCoordinate.X; leftOffset++)
            {
                Coordinate c = new Coordinate() { X = leftOffset, Y = currentCoordinate.Y };

                movement_coordinates.Add(c);
            }

            #endregion


        }


        return this.movement_coordinates;
    }


}
