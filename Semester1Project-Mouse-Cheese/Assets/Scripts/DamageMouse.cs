using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMouse: MonoBehaviour
{
    public int damage = 1;
    
    public float coolDownTime = 5;

    private float coolDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time > coolDown)
        {
            if (collision.CompareTag("Cheese"))
            {
                HealthCheese.Singleton.CheeseDamage(damage);
                coolDown = Time.time + coolDownTime;
            }
        }

    }
}
