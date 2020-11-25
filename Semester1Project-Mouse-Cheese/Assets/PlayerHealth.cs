using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    private void Start()
    {
        if (gameObject.tag == "Cheese")
        {
            maxHealth = 3f;
        }
        else
        {
            maxHealth = 2f;
        }
        currentHealth = maxHealth;
    }

    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Mouse")
        {
            if(collision.gameObject.tag == "Cheese")
            {
                currentHealth--;
            }
            if(currentHealth < 1f)
            {
                Destroy(gameObject);
            }
        }
        if(gameObject.tag == "Mounts")
        {
            if (collision.gameObject.tag == "Mouse")
            {
                currentHealth--;
            }
            if(currentHealth < 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
