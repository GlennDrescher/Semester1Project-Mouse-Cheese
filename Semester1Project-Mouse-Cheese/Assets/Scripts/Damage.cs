using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage: MonoBehaviour
{
    public int damageAmount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health H = other.GetComponent<Health>();

        if(H == null) return;

        H.currentHealth = H.currentHealth - damageAmount;
    }
}
