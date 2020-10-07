﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public GameObject objectToCheck1;
    public GameObject objectToCheck2;
    public float distanceToObject = 15f;
    public Camera playerCam1;
    public Camera playerCam2;
    public Camera allPlayerCam;
    
    private void Start()
    {
        playerCam1.enabled = true;
        playerCam2.enabled = true;
        allPlayerCam.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(objectToCheck1.transform.position, objectToCheck2.transform.position) <= distanceToObject)
        {
            playerCam1.enabled = false; 
            playerCam2.enabled = false;
            allPlayerCam.enabled = true;
        }

        if (Vector3.Distance(objectToCheck1.transform.position, objectToCheck2.transform.position) >= distanceToObject)
        {
            playerCam1.enabled = true;
            playerCam2.enabled = true;
            allPlayerCam.enabled = false;
        }
    }
}

