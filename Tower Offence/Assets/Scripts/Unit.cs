using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string monsterName;
    public float speed;
    public float health;
    public float cost;
    public float healthDamage;
    public float moneyGainedPerTile;
    public string info;
    public string ability;
    public Sprite image;
    public Transform skele;
    public AudioClip deathClip;
    public SoundEffectManager SEM;
    public GameObject inspiration;

  
    Vector3 lastPosition;   
    
    User user;
    public Transform[] points;

    public int pointIndex = 0;
    
    private void Start()
    {
        points = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>().waypoints;
        user = FindObjectOfType<User>();
        SEM = GameObject.Find("SoundEffectsManager").GetComponent<SoundEffectManager>();
        lastPosition = transform.position;
        
        if(monsterName == "Crisp")
        {
            Transform[] tempPoints = new Transform[2] {points[0], points[points.Length-1] };
            points = tempPoints;
        }
       
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
                
                SEM.RequestPlayEffect(deathClip);
                Destroy(gameObject);
            }
            transform.position = Vector2.MoveTowards(transform.position, points[pointIndex].position, Time.deltaTime * speed);
            if (Vector2.Distance(transform.position, points[pointIndex].position) <= 0.1f)
            {
                if (pointIndex != points.Length - 1)
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
    public void Inspire()
    {
        healthDamage += 2;
        health += 5;
        moneyGainedPerTile += 5;
        Instantiate(inspiration,transform);

    }

   
}
