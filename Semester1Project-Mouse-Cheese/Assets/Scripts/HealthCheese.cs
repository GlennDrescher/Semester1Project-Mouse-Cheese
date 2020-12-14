using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCheese : MonoBehaviour
{
    public static HealthCheese Singleton;
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
    public void CheeseDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            GameWin.Singleton.Mousewin();
            Destroy(gameObject);
        }
    }
}
