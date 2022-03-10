using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class AI : MonoBehaviour
{

    [SerializeField] Tilemap baseTiles;
    [SerializeField] Tilemap tilesTaken;
    [SerializeField] List<GameObject> tower1;
    public User user;
    int money = 0;
    float timerMax = 1;
    float timer = 1;



    // Update is called once per frame
    void Update()
    {
        if (!user.isGameOver)
        {
            if (timer <= 0)
            {
                timer = timerMax;
                money += 20;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            if (money == 100)
            {
                Vector3 potentialLocation = new Vector3(Random.Range(-15, 15) - 0.5f, Random.Range(-6, 6) - 0.5f);
                List<Vector3> locationChecks = new List<Vector3>() { potentialLocation + Vector3.right, potentialLocation - Vector3.right, potentialLocation + Vector3.up, potentialLocation - Vector3.up };

                if (baseTiles.GetTile<Tile>(baseTiles.layoutGrid.WorldToCell(potentialLocation)).name != "grass-tiles-2-small_3" && Uitls.CheckLocations(locationChecks, baseTiles, "grass-tiles-2-small_3"))
                {
                    Instantiate(tower1[0], potentialLocation, Quaternion.identity);
                    money -= 100;
                }

                //Vector3Int tile = baseTiles.layoutGrid.WorldToCell(new Vector3(0,0,0));
                //Debug.Log(baseTiles.GetTile<Tile>(tile));
            }
        }
    }
}
