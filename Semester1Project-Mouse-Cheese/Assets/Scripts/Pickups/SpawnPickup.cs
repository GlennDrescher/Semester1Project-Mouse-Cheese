using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnPickup : MonoBehaviour
{

    private GameObject[] pickups;

    // Start is called before the first frame update
    void Start()
    {
        pickups = Resources.LoadAll("Spawnables/Pickups", typeof(GameObject)).Cast<GameObject>().ToArray<GameObject>();
        Instantiate(pickups[Random.Range(0, pickups.Length)], transform.position, transform.rotation);
    }

    
}
