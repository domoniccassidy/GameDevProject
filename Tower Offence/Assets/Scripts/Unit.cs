using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string monsterName;
    public float speed;
    public float health;
    public float cost;
    public float healthDamage;
    public float moneyGainedPerTile;
    public string info;
    public Transform skele;

  
    Vector3 lastPosition;   
    
    User user;
    public Waypoints points;
    public int pointIndex = 0;
    
    private void Start()
    {
        points = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        
        user = FindObjectOfType<User>();
        lastPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        if (!user.isGameOver && !user.isPaused)
        {

            if (lastPosition.x - transform.position.x >= 1 || lastPosition.x - transform.position.x <= -1 || lastPosition.y - transform.position.y >= 1 || lastPosition.y - transform.position.y <= -1)
            {
                lastPosition = transform.position;
                user.MakeMoney(moneyGainedPerTile);
            }
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            transform.position = Vector2.MoveTowards(transform.position, points.waypoints[pointIndex].position, Time.deltaTime * speed);
            if (Vector2.Distance(transform.position, points.waypoints[pointIndex].position) <= 0.1f)
            {
                if (pointIndex != points.waypoints.Length - 1)
                {
                    pointIndex += 1;

                }

            }
        }
    }
   
    public void Damage(float damage)
    {
        health -= damage;

    }

   
}
