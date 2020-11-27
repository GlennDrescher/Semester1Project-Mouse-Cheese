using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Players starting health.
    public float maxHealth = 3f;

    //Players current health.
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
}
