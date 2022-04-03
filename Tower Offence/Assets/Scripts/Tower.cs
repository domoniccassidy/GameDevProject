using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{

    public Vector3 projectileShootFromPosition;
    public float shotDelay;
    float sinceLastShot = 0;
    public GameObject arrow;
    public string towerName;
    public float pierce;
    public float cost;
    public string info;
    public float range;
    public float damage;
    public float shots;


    User user;
    private Transform enemy;
    private Collider2D[] colliders;

    private void Start()
    {
        user = FindObjectOfType<User>();
        range = GetComponent<CircleCollider2D>().radius;
        
    }
    private void Update()
    {
        if (!user.isGameOver && !user.isPaused)
        {
            if (sinceLastShot >= shotDelay)
            {
                colliders = Physics2D.OverlapCircleAll(transform.position, 1.53f);
                foreach (var item in colliders)
                    {
                        if (item.GetComponent<Unit>() != null)
                        {
                            enemy = item.transform;
                            break;
                        }
                        else { enemy = null; }
                    }
                foreach (var item in colliders)
                {
                    if (item.GetComponent<Unit>() != null)
                    {
                        if (item.GetComponent<Unit>().monsterName == "Shronk")
                        {
                            enemy = item.transform;
                            break;
                        }

                    }
              
                }
                sinceLastShot -= shotDelay;
                if (enemy != null && towerName != "Circle Tower")
                {
                    DiamondShot();
                }
                else if(enemy != null && towerName == "Circle Tower")
                {
                  
                    CircleShot();
                }
                else
                {

                }
            }

            sinceLastShot += Time.deltaTime;
        }
    }
    void DiamondShot()
    {

        GameObject arrowRef = Instantiate(arrow, transform);
        Vector3 dir = enemy.position - arrowRef.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrowRef.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        arrowRef.transform.Rotate(new Vector3(0, 0, 85));
        arrowRef.GetComponent<ArrowScript>().damage = damage;
        arrowRef.GetComponent<ArrowScript>().enemy = enemy;
        arrowRef.GetComponent<ArrowScript>().pierce = pierce;
        arrowRef.GetComponent<ArrowScript>().towerFiredFrom = towerName;
    }
    void CircleShot() 
    {
        
        for (int i = 0; i < shots; i++)
        {
            
            GameObject arrowRef = Instantiate(arrow, transform);
            arrowRef.transform.Rotate(i * new Vector3(0,0,45));
            
            arrowRef.GetComponent<ArrowScript>().lifeSpan = 0.2f;
            arrowRef.GetComponent<ArrowScript>().damage = damage;
            arrowRef.GetComponent<ArrowScript>().pierce = pierce;
            arrowRef.GetComponent<ArrowScript>().towerFiredFrom = towerName;
        }
    }
    

  
}
