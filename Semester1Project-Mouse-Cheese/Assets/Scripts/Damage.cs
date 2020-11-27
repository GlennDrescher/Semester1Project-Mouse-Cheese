using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage: MonoBehaviour
{
    [SerializeField] private Health _Health;

    private float doDamage;

    public float damage = 1;

    public float coolDownTime = 5;

    private float coolDown;

    private void Start()
    {
        doDamage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time > coolDown)
        {
            if (collision.CompareTag("Cheese"))
            {
                PlayerDamage();
                coolDown = Time.time + coolDownTime;
            }
        }
        
    }
    void PlayerDamage()
    {
        _Health.currentHealth = _Health.currentHealth - doDamage;
        _Health.UpdateHealth();
    }
}
