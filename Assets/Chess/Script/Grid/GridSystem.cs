using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private GridConfig currentConfig = null;

    private void Start()
    {
        CreateGrid();
    }


    public void CreateGrid()
    {
        
        if (currentConfig == null) return;
        bool iswhite = false;

        for(int y=0; y<currentConfig.GridY;y++)
        {
            iswhite = !iswhite;
            for(int x =0; x<currentConfig.GridX; x++)
            {
                var grid = Instantiate(currentConfig.gridPrefab, new Vector3(x, 1, y),Quaternion.identity) as Grid;

                if (iswhite) grid.SetGrid(x, y, Color.white);
                else grid.SetGrid(x, y, Color.black);
                iswhite = !iswhite;
            }
        }

    }


    private void LogError(string msg)
    {
        Debug.LogError("[Grid System] : " + msg);
    }
}
