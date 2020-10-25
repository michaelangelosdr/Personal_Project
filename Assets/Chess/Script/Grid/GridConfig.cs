using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Grid config",menuName ="Chess/Config/Grid")]
public class GridConfig : ScriptableObject
{
    [SerializeField] public int GridX = 0;
    [SerializeField] public int GridY = 0;

    [SerializeField] public Color[] boardColors;

    [SerializeField] public Grid gridPrefab;
}

