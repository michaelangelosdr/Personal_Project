using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(MeshRenderer))]
public class Queen : BoardPiece, IChessPiece
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
        pieceName = "Queen";
        ptype = PieceType.CHESS_QUEEN;
        base.InitializePiece(color, spawnLoc, onPieceSelect);
    }


    public override List<Coordinate> getMovement()
    {
        if (movement_coordinates == null || movement_coordinates.Count == 0)
        {
            movement_coordinates = new List<Coordinate>();

            int xOfset = currentCoordinate.X - 1;
            int yOfset = currentCoordinate.Y - 1;
            #region X+1 Y+1
            xOfset = currentCoordinate.X + 1;
            yOfset = currentCoordinate.Y + 1;

            while (xOfset <= 7 && yOfset <= 7)
            {
                Coordinate c = new Coordinate();
                c.X = xOfset++;
                c.Y = yOfset++;

                movement_coordinates.Add(c);
            }
            #endregion

            #region x-1 y+1
            //x+1 y-1
            xOfset = currentCoordinate.X + 1;
            yOfset = currentCoordinate.Y - 1;

            while (xOfset <= 7 && yOfset >= 0)
            {
                Coordinate c = new Coordinate();
                c.X = xOfset++;
                c.Y = yOfset--;

                movement_coordinates.Add(c);
            }

            #endregion

            #region X-1 Y -1

            xOfset = currentCoordinate.X - 1;
            yOfset = currentCoordinate.Y - 1;

            while (xOfset >= 0 && yOfset >= 0)
            {
                Coordinate c = new Coordinate();
                c.X = xOfset--;
                c.Y = yOfset--;

                movement_coordinates.Add(c);
            }
            #endregion

            #region x-1 y+1

            xOfset = currentCoordinate.X - 1;
            yOfset = currentCoordinate.Y + 1;

            while (xOfset >= 0 && yOfset <= 7)
            {
                Coordinate c = new Coordinate();
                c.X = xOfset--;
                c.Y = yOfset++;

                movement_coordinates.Add(c);
            }

            #endregion

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
