using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public Vector3 projectileShootFromPosition;
    public float shotDelay;
    float sinceLastShot = 0;
    public GameObject arrow;
    public User user;

    private Transform enemy;
    private Collider2D[] colliders;

    private void Start()
    {
        user = FindObjectOfType<User>();
    }
    private void Update()
    {
        if (!user.isGameOver)
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

                sinceLastShot -= shotDelay;
                if (enemy != null)
                {

                    GameObject arrowRef = Instantiate(arrow, transform);
                    Vector3 dir = enemy.position - arrowRef.transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    arrowRef.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    arrowRef.transform.Rotate(new Vector3(0, 0, 85));
                    arrowRef.GetComponent<ArrowScript>().enemy = enemy;

                }
            }

            sinceLastShot += Time.deltaTime;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.CompareTag("Player") && enemy == null)

    //    {
    //        enemy = collision.transform;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        enemy = null;
    //    }
    //}
}
