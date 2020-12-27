using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mouse" || collision.gameObject.tag == "Cheese" || collision.gameObject.tag == "Mounts")
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            var playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            StartCoroutine(IncreasePlayerSpeed(playerMovement));
        }
    }

    private IEnumerator IncreasePlayerSpeed(PlayerMovement playerMovement)
    {
        float originalSpeed = playerMovement.moveSpeed;
        playerMovement.moveSpeed *= (float)1.2;
        yield return new WaitForSeconds(5);
        playerMovement.moveSpeed = originalSpeed;
        Destroy(gameObject);
        
    }
}
