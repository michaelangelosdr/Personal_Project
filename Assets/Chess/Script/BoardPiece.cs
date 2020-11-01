using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoardPiece : MonoBehaviour
{
    [SerializeField] public float MoveTime = 1;

    [SerializeField] public string pieceName;
    [SerializeField] public Coordinate currentCoordinate;
    [SerializeField] public List<Coordinate> movement_coordinates;
    [SerializeField] public Coordinate[] attack_coordinates;

    //private Event selectEvent;

    private Action<BoardPiece> pieceSelected;

    private Color _piececolor;
    public Color pieceColor
    {
        get { return _piececolor; }
        set
        {
            _piececolor = value;
            try
            {
                this.GetComponent<MeshRenderer>().material.color = _piececolor;

            }
            catch { }
        }
    }

    public virtual void InitializePiece(Color color, Coordinate spawnLoc,Action<BoardPiece> onPieceSelect)
    {
        currentCoordinate = spawnLoc;
        movement_coordinates = null;
        pieceColor = color;

        pieceSelected += onPieceSelect;

    }

    
    /// <summary>
    /// Override to set movement
    /// </summary>
    public virtual List<Coordinate> getMovement()
    {
        Debug.Log("MoveMent empty");

        return movement_coordinates;
    }

    public IEnumerator Move(Coordinate targetCoordinate)
    {
        Debug.Log(CheckMove(targetCoordinate));
       if(CheckMove(targetCoordinate))
        {
            this.transform.position = new Vector3(currentCoordinate.X, 2,currentCoordinate.Y);
            LeanTween.moveLocal(this.gameObject, new Vector3(targetCoordinate.X, 2, targetCoordinate.Y), MoveTime);
            yield return new WaitForSeconds(MoveTime);
            currentCoordinate = targetCoordinate;
            movement_coordinates = null;
        }

        yield return null;
    }

    private bool CheckMove(Coordinate targetCoordinate)
    {

        foreach (Coordinate c in movement_coordinates)
        {
            if(targetCoordinate.X == c.X && targetCoordinate.Y == c.Y) { return true; }
        }
        return false;
    }



    private void OnMouseDown()
    {
        pieceSelected?.Invoke(this);
    }

}

