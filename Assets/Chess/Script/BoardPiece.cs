using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour
{
   [SerializeField] private PieceType pieceType;
    [SerializeField] private MovementProp[] movementProp;
    [SerializeField] private AttackProp[] attackProp;
    [SerializeField] private bool Attack_is_same_with_movement;

}
