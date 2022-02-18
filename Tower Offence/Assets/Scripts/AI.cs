using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AI : MonoBehaviour
{

    [SerializeField] Tilemap baseTiles;
    [SerializeField] Tilemap tilesTaken;
    [SerializeField] GameObject tower1;
    int money = 0;
    float timerMax = 1;
    float timer = 1;
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = timerMax;
            money += 10;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if(money == 100)
        {
            Vector3 potentialLocation = new Vector3(Random.RandomRange(-15,15)-0.5f,Random.RandomRange(-6,6) - 0.5f);

            
            if (baseTiles.GetTile<Tile>(baseTiles.layoutGrid.WorldToCell(potentialLocation)).name != "grass-tiles-2-small_3")
            {
                Instantiate(tower1, potentialLocation, Quaternion.identity);
                money -= 100;
            }
            
            //Vector3Int tile = baseTiles.layoutGrid.WorldToCell(new Vector3(0,0,0));
            //Debug.Log(baseTiles.GetTile<Tile>(tile));
        }
    }
}
