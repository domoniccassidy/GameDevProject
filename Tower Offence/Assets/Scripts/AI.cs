using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class AI : MonoBehaviour
{

    [SerializeField] Tilemap baseTiles;
    [SerializeField] Tilemap numberTiles;
    [SerializeField] List<GameObject> tower1;
    public AlertAiTo3 alert3;
    public AlertAiTo4 alert4;
    public User user;
    public int money;
    float timerMax = 1;
    float timer = 1;
    public int moneyConstant;

  

    int towerSelect;
    bool newTower;
  
    List<List<Vector3Int>> spawnPrio = new List<List<Vector3Int>>()
    {
        new List<Vector3Int>(),
        new List<Vector3Int>(),
        new List<Vector3Int>(),
        new List<Vector3Int>()
    };
    List<Vector3Int> allSpawn = new List<Vector3Int>();
    // Update is called once per frame
   
    void Update()
    {
        if(user.isGameOver || user.isPaused)
        {
            return;
        }
        if (!newTower)
        {
            towerSelect = Random.Range(0, 10000);
            newTower = true;
        }
        if (!user.isGameOver)
        {
            if (timer <= 0)
            {
                timer = timerMax;
                money += moneyConstant;
            }
            else
            {
                timer -= Time.deltaTime;
            }
           
            if(towerSelect > 6000 && spawnPrio[1].Count < 1)
            {
                towerSelect -= 4000;
            }

            if (alert4.Alert4 && towerSelect < 10000 && spawnPrio[3].Count != 0)
            {
                towerSelect += 20000;
            }
            else if (alert3.Alert3 && towerSelect < 10000)
            {

                towerSelect += 10000;

            }
            

           
            if (towerSelect < 6000)
            {
                if(money >= 100)
                {
                    int choosePos = Random.Range(0, spawnPrio[0].Count);
                    Instantiate(tower1[0],numberTiles.GetCellCenterWorld(spawnPrio[0][choosePos]), Quaternion.identity);
                    spawnPrio[0].RemoveAt(choosePos);
                    newTower = false;
                    money -= 100;
                }
            }
           else if (towerSelect >= 6000 && towerSelect <10000)
            {
                if (money >= 200)
                {
                    int choosePos = Random.Range(0, spawnPrio[1].Count);
                    Instantiate(tower1[1], numberTiles.GetCellCenterWorld(spawnPrio[1][choosePos]), Quaternion.identity);
                    spawnPrio[1].RemoveAt(choosePos);
                    newTower = false;
                    money -= 200;
                }
            }
            else if (towerSelect >= 10000 && towerSelect < 20000)
            {
                if(towerSelect > 18000)
                {
                    if (money >= 200)
                    {
                        int choosePos = Random.Range(0, spawnPrio[2].Count);
                        Instantiate(tower1[1], numberTiles.GetCellCenterWorld(spawnPrio[2][choosePos]), Quaternion.identity);
                        spawnPrio[2].RemoveAt(choosePos);
                        newTower = false;
                        money -= 200;
                    }
                }
                else
                {

                    if(user.TimeLeft < 125 && money >= 300)
                    {
                        
                        int choosePos = Random.Range(0, spawnPrio[2].Count);
                        Instantiate(tower1[2], numberTiles.GetCellCenterWorld(spawnPrio[2][choosePos]), Quaternion.identity);
                        spawnPrio[2].RemoveAt(choosePos);
                        newTower = false;
                        money -= 300;
                    }
                    else if (money >= 100 && user.TimeLeft > 125)
                    {
                        int choosePos = Random.Range(0, spawnPrio[2].Count);
                        Instantiate(tower1[0], numberTiles.GetCellCenterWorld(spawnPrio[2][choosePos]), Quaternion.identity);
                        spawnPrio[2].RemoveAt(choosePos);
                        newTower = false;
                        money -= 100;
                    }
                    
                }
               
            }
            else if (towerSelect >= 20000)
            {
               
                if(towerSelect > 28000)
                {
                    if (money >= 200)
                    {
                        int choosePos = Random.Range(0, spawnPrio[3].Count);
                        Instantiate(tower1[1], numberTiles.GetCellCenterWorld(spawnPrio[3][choosePos]), Quaternion.identity);
                        spawnPrio[3].RemoveAt(choosePos);
                        newTower = false;
                        money -= 200;
                    }
                }
                else
                {
                    if (user.TimeLeft < 125 && money >= 300)
                    {

                        int choosePos = Random.Range(0, spawnPrio[2].Count);
                        Instantiate(tower1[2], numberTiles.GetCellCenterWorld(spawnPrio[2][choosePos]), Quaternion.identity);
                        spawnPrio[2].RemoveAt(choosePos);
                        newTower = false;
                        money -= 300;
                    }
                   else  if (money >= 100  && user.TimeLeft > 125)
                    {
                        int choosePos = Random.Range(0, spawnPrio[3].Count);
                        Instantiate(tower1[0], numberTiles.GetCellCenterWorld(spawnPrio[3][choosePos]), Quaternion.identity);
                        spawnPrio[3].RemoveAt(choosePos);
                        newTower = false;
                        money -= 100;
                    }
                }
               
            }



      
        }
    }
    void Start()
    {
     
        towerSelect = Random.Range(0, 10000);
        newTower = true;
        for (int x = numberTiles.cellBounds.min.x; x < numberTiles.cellBounds.max.x; x++)
        {
            for (int y = numberTiles.cellBounds.min.y; y < numberTiles.cellBounds.max.y; y++)
            {
                Tile currentTile = numberTiles.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (currentTile != null)
                {
                    switch (currentTile.name)
                    {
                        case "Numbers_1":
                            spawnPrio[0].Add(new Vector3Int(x,y,0));
                            break;
                        case "Numbers_2":
                            spawnPrio[1].Add(new Vector3Int(x,y,0));
                            break;
                        case "Numbers_3":
                            spawnPrio[2].Add(new Vector3Int(x, y, 0));
                            break;
                        case "Numbers_4":
                            spawnPrio[3].Add(new Vector3Int(x, y, 0));
                            break;
                        default:
                            break;
                    }
                    allSpawn.Add(new Vector3Int(x, y, 0));
                }
            }
        }
    }
}
