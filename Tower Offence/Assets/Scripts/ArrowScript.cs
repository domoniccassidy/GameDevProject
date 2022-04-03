using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public Transform enemy;
    public float damage ;
    public string towerFiredFrom;
    float timeSinceFired = 0;
    public float lifeSpan =1;
    public float pierce ;
 
    User user;

    private void Start()
    {
        user = FindObjectOfType<User>();
 

    }
    private void Update()
    {
        
        if (user.isGameOver)
        {
            Destroy(gameObject);
        }
        if (user.isPaused)
        {
            return;
        }

        if (timeSinceFired > lifeSpan)
        {
            Destroy(gameObject);
           
        }
        
        if (enemy != null && towerFiredFrom == "Tower")
        {
            
            Vector3 target = (enemy.position - transform.position).normalized;
            transform.position += target * Time.deltaTime * moveSpeed;
            timeSinceFired += Time.deltaTime;
        }
        else if(towerFiredFrom == "Circle Tower")
        {

            Vector3 target = transform.forward;
            transform.position -= transform.up * Time.deltaTime * moveSpeed;
            timeSinceFired += Time.deltaTime;
        }
        else if(towerFiredFrom == "Power Tower")
        {
            transform.position -= transform.up * Time.deltaTime * moveSpeed;
            timeSinceFired += Time.deltaTime;
        }
        else
        {
            
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Unit>().Damage(damage);
       
        pierce -= 1;
        if(pierce == 0)
        {
            Destroy(gameObject);
        }
        
       
    }
}
