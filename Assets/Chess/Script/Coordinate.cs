using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Coordinate
{

    public int X;
    public int Y;

}


// CurrentX + targetX = TargetX 
// CurrentY + targetY = TargetY 

//BoardX - currentX = TargetX
// 8 - 0 = 8
// 8 - 1 = 7 


//CurrentX + targetX(1) = TargetX;
//CurrentY + 2 = TargetY



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