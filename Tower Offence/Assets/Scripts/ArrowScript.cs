using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public Transform enemy;
    public float damage = 2;
    float timeSinceFired = 0;
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

        if (timeSinceFired > 2)
        {
            Destroy(gameObject);
        }
        if (enemy != null)
        {
            Vector3 target = (enemy.position - transform.position).normalized;
            transform.position += target * Time.deltaTime * moveSpeed;
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
