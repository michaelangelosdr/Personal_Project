using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MovementProp
{
    [SerializeField] public bool isNull = false;
    [SerializeField] public OmniDirection direction;
    [SerializeField] public int Distance = 1;
    [SerializeField] public ExtraProp extraProp;
}


[Serializable]
public class ExtraProp
{
    [SerializeField] public bool isNull = true;
    [SerializeField] public OmniDirection direction;
    [SerializeField] public int Distance = 1;
    [SerializeField] public MovementProp extraProp;
}


[Serializable]
public class OmniDirection
{

   [SerializeField] DIRECTION dir;
   [SerializeField] public float X { set { X = value; SetDirection(); } get { return X; } }
   [SerializeField] public float Y { set { Y = value; SetDirection(); } get { return Y; } }
    
   private void SetDirection()
    {
       if(X == 0 && Y == 1)
        {
            dir = DIRECTION.NORTH;
        }
       else if(X==0 && Y==-1)
        {
            dir = DIRECTION.SOUTH;
        }
       else if(X==1 && Y ==0)
        {
            dir = DIRECTION.WEST;
        }
        else if (X == -1 && Y == 0)
        {
            dir = DIRECTION.WEST;
        }

    }

    

}


public enum DIRECTION
{ 
    NORTH,
    SOUTH,
    EAST,
    WEST,
    NORTH_EAST,
    NORTH_WEST,
    SOUTH_EAST,
    SOUTH_WEST
}