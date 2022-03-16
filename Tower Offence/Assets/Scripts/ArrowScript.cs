using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public Transform enemy;
    public float damage = 2;
    public string towerFiredFrom;
    float timeSinceFired = 0;
    public float lifeSpan =1;
    User user;
    Vector3 originalTransform;
    private void Start()
    {
        user = FindObjectOfType<User>();
        originalTransform = transform.position;
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
        if (enemy != null && towerFiredFrom != "Circle")
        {
            Vector3 target = (enemy.position - transform.position).normalized;
            transform.position += target * Time.deltaTime * moveSpeed;
            timeSinceFired += Time.deltaTime;
        }
        else if(towerFiredFrom == "Circle")
        {

            Vector3 target = transform.forward;
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

        Destroy(gameObject);
    }
}
