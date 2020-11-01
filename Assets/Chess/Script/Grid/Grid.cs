using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Grid : MonoBehaviour
{
    [SerializeField] public MeshRenderer meshRenderer = null;
    [SerializeField] public int X = 0;
    [SerializeField] public int Y = 0;
    [SerializeField] public Color initialColor;

    UnityAction<Grid> selectGridAction;

    public void SetGrid(int x, int y, Color color)
    {
        X = x;
        Y = y;
        meshRenderer.material.color = color;
        initialColor = color;
    }

    public void SetGrid(int x, int y, Color color, UnityAction<Grid> onGridSelect)
    {
        X = x;
        Y = y;
        meshRenderer.material.color = color;
        initialColor = color;

        selectGridAction = onGridSelect;
    }


    public void SetColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    public void ResetColor(Color color)
    {
        meshRenderer.material.color = color;
    }


    private void OnMouseDown()
    {
        selectGridAction?.Invoke(this);
    }

}
