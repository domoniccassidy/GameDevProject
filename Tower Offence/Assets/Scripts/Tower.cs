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


    User user;
    private Transform enemy;
    private Collider2D[] colliders;

    private void Start()
    {
        user = FindObjectOfType<User>();
        
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
                if (enemy != null && towerName == "Diamond")
                {
                    DiamondShot();
                }
                else if(enemy != null && towerName == "Circle")
                {
                    CircleShot();
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
        arrowRef.GetComponent<ArrowScript>().enemy = enemy;
    }
    void CircleShot() 
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject arrowRef = Instantiate(arrow, transform);
            arrowRef.transform.Rotate(i * new Vector3(0,0,45));
            arrowRef.GetComponent<ArrowScript>().lifeSpan = 0.2f;
            arrowRef.GetComponent<ArrowScript>().towerFiredFrom = towerName;
        }
       
    }

  
}
