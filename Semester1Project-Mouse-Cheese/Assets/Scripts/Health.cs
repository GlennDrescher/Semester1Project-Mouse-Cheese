using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Players starting health.
    public float maxHealth = 3;

    //Players current health.
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
