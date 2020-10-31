using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] public GridConfig currentConfig = null;


    public void CreateGrid()
    {
        
        if (currentConfig == null) return;
        bool iswhite = false;


        if (currentConfig.currentGrid == null || currentConfig.currentGrid.Length == 0)
        {
            currentConfig.currentGrid = new Grid[currentConfig.GridX, currentConfig.GridY];
        }
        for(int y=0; y<currentConfig.GridY;y++)
        {
            iswhite = !iswhite;
            for(int x =0; x<currentConfig.GridX; x++)
            {
                var grid = Instantiate(currentConfig.gridPrefab, new Vector3(x, 1, y),Quaternion.identity) as Grid;
                grid.gameObject.name ="grid [X:" + x + "Y:" + y + "]";
                if (iswhite) grid.SetGrid(x, y, Color.white);
                else grid.SetGrid(x, y, Color.black);
                iswhite = !iswhite;

                currentConfig.currentGrid[x, y] = grid;
            }
        }

    }


    private void LogError(string msg)
    {
        Debug.LogError("[Grid System] : " + msg);
    }
}
