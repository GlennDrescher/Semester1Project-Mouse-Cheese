using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_ActivateMinimap : MonoBehaviour
{

    private Canvas minimap = null;

    // Start is called before the first frame update
    void Start()
    {
        minimap = GameObject.Find("Minimap").GetComponent<Canvas>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cheese" || collision.gameObject.tag == "Mouse" || collision.gameObject.tag == "Mounts")
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(ActivateMinimapForXseconds(5f));
        }
    }

    private IEnumerator ActivateMinimapForXseconds(float x)
    {
        minimap.enabled = true;
        yield return new WaitForSeconds(x);
        minimap.enabled = false;
        Destroy(gameObject);
    }
}
