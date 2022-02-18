using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float health;
    

    Waypoints points;
    int pointIndex = 0;
    private void Start()
    {
        points = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points.waypoints[pointIndex].position, Time.deltaTime * speed) ;
        if (Vector2.Distance(transform.position,points.waypoints[pointIndex].position) <=0.1f)
        {
            if (pointIndex != points.waypoints.Length -1)
            {
                pointIndex += 1;
                
            }
           
        }
    }
}
