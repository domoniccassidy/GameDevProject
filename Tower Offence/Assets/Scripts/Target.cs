using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public User user;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.GetComponent<Unit>();
        user.TakeHealth(unit.healthDamage);
        Destroy(collision.gameObject);
        
    }
}
