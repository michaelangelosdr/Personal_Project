using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] public MeshRenderer meshRenderer = null;
    [SerializeField] public int X = 0;
    [SerializeField] public int Y = 0;
    [SerializeField] public Color initialColor;


    public void SetGrid(int x, int y, Color color)
    {
        X = x;
        Y = y;
        meshRenderer.material.color = color;
        initialColor = color;
    }

    public void SetColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    public void ResetColor(Color color)
    {
        meshRenderer.material.color = color;
    }
}
