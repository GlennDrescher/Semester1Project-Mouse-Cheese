using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMouse : MonoBehaviour
{
    public static HealthMouse Singleton;
    public int MaxHealth = 3;
    public int CurrentHealth;

    private void Awake()
    {
        Singleton = this;
    }
    public void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void MouseDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            GameWin.Singleton.Cheesewin();
            Destroy(gameObject);
        }
    }
}
