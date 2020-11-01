using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(MeshRenderer))]
public class Knight : BoardPiece, IChessPiece
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
        pieceName = "Knight";
        ptype = PieceType.CHESS_KNIGHT;
        base.InitializePiece(color, spawnLoc, onPieceSelect);
    }


    public override List<Coordinate> getMovement()
    {
        if (movement_coordinates == null || movement_coordinates.Count == 0)
        {
            movement_coordinates = new List<Coordinate>();

            int xOffset = currentCoordinate.X;
            int yOffset = currentCoordinate.Y;

            #region Q1

            if (xOffset <= 7-1 && yOffset <= 7 - 2)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X + 1;
                c.Y = currentCoordinate.Y + 2;
                movement_coordinates.Add(c);
            }
            if (xOffset <= 7 - 2 && yOffset <= 7 - 1)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X + 2;
                c.Y = currentCoordinate.Y + 1;
                movement_coordinates.Add(c);
            }
            #endregion

            #region Q2

            if (xOffset <= 7 - 1 && yOffset >= 2)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X + 1;
                c.Y = currentCoordinate.Y - 2;
                movement_coordinates.Add(c);
            }

            if (xOffset <= 7 - 2 && yOffset >= 1)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X + 2;
                c.Y = currentCoordinate.Y - 1;
                movement_coordinates.Add(c);
            }


            #endregion

            #region Q3

            if (xOffset >= 2 && yOffset >= 1)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X - 2;
                c.Y = currentCoordinate.Y - 1;
                movement_coordinates.Add(c);
            }

            if (xOffset >= 1 && yOffset >= 2)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X - 1;
                c.Y = currentCoordinate.Y - 2;
                movement_coordinates.Add(c);
            }




            #endregion


            #region Q4

            if (xOffset >= 1 && yOffset <= 7-2)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X - 1;
                c.Y = currentCoordinate.Y + 2;
                movement_coordinates.Add(c);
            }

            if (xOffset >= 2 && yOffset <= 7-1)
            {
                Coordinate c = new Coordinate();
                c.X = currentCoordinate.X -2;
                c.Y = currentCoordinate.Y + 1;
                movement_coordinates.Add(c);
            }




            #endregion

        }


        return this.movement_coordinates;
    }


}
