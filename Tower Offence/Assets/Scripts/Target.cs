using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public User user;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Unit unit = collision.GetComponent<Unit>();
        if (unit.monsterName == "Father Time")
        {
            user.TimeLeft = 200;
            user.timeText.text = "200";
        }
        user.TakeHealth(unit.healthDamage);
        Destroy(collision.gameObject);
       
    }
}
