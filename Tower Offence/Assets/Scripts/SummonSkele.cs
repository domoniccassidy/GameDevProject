using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSkele : MonoBehaviour
{
    public Waypoints points;
    public GameObject skele;
    Unit unit;
    
    public float spawnTime = 4;
    void Start()
    {
        points = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        unit = GetComponent<Unit>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
           GameObject skeleRef = Instantiate(skele, points.waypoints[unit.pointIndex + 2].transform.position, Quaternion.Euler(0,-180,0));
            skeleRef.GetComponent<Unit>().pointIndex = unit.pointIndex + 3;
            spawnTime += 4;
        }
    }
}
