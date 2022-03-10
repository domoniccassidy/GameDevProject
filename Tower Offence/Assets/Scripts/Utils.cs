using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Uitls
{
   static public bool CheckLocations(List<Vector3> locations, Tilemap baseTiles, string tilename )
    {
        bool isValid = false;
        foreach (var item in locations)
        {
            if (baseTiles.GetTile<Tile>(baseTiles.layoutGrid.WorldToCell(item)).name == tilename)
            {
                isValid = true;
            }
        }
        return isValid;
    }
    
}

