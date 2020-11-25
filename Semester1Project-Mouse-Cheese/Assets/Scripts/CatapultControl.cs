﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatapultControl : MonoBehaviour

{
    private GameObject colcheck = null;
    private GameObject catapult;
    private Vector2 mountpos;
    public float catapultedSpeed = 70;
    public string playerInteractionKey;
    private bool flyingToggle = false;
    public bool cheeseFlying = false;
    

    

    // Start is called before the first frame update
    void Start()
    {
        catapult = GameObject.Find("catapult");
    }

    // Update is called once per frame
    void Update()
    {
        if (flyingToggle == true)
        {
            if (colcheck != null)
            {
                cheeseFlying = true;
               
            }
            
        }

        if (cheeseFlying == true)
        {
            mountpos = GameObject.FindGameObjectWithTag("Mounts").transform.position;


            //Physics2D.IgnoreCollision = false;
            //gameObject.GetComponent<Rigidbody2D>().GetComponent<> = false;
            //Physics2D.IgnoreCollision(gameObject.GetComponent<PolygonCollider2D>(), GameObject.FindGameObjectWithTag("Walls").GetComponent<TileMapCollider2D>());
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;

            gameObject.transform.position = Vector3.MoveTowards(transform.position, mountpos, catapultedSpeed * Time.deltaTime);
            if (gameObject.transform.position.x == mountpos.x && gameObject.transform.position.y == mountpos.y)
            {
                if (cheeseFlying == true)
                {
                    colcheck = null;
                    GameObject mountObject = GameObject.FindGameObjectWithTag("Mounts");

                    

                    gameObject.GetComponent<PlayerMovement>().PlayerMounting();
                    
                    cheeseFlying = false;
                    Debug.Log("Variables should be disabled.");
                    
                    

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space/*husk playerInteractionKey her*/))
        {

            flyingToggle = true;


            
        }
        if(Input.GetKeyUp(KeyCode.Space /*husk playerInteractionKey her*/))
        {
            flyingToggle = false;
        }
    }

    //Check for collision with catapult
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("djdjd");
        if (collision.gameObject.tag.Equals("catapult") == true)
        {
            Debug.Log("Virker det her??");
            

            
            
            //Check if this gameobject is a cheese
            if (gameObject.tag.Equals("Cheese"))
            {

                colcheck = collision.gameObject;





                Debug.Log("Test");

            }
            
        }
        
       
    }
    
    

    /*IEnumerator charMove()
    {
        charCheck = OnCollision2D()

    }*/
    


}
