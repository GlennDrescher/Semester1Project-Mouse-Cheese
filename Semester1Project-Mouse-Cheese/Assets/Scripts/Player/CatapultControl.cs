using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatapultControl : MonoBehaviour

{
    private GameObject colcheck = null; //colliion check switch between player and catapult. Contains the catapult.
    private GameObject catapult; //Contrains only catapult without collision check.
    private Vector2 mountpos; //Position of the cat.
    public float catapultedSpeed = 100; //Speed of the cheese when launched by catapult.
    public string playerInteractionKey; //Soon to be depricated. Used as placeholder for the actual interaction key.
    private bool buttonPress = false; //Button press switch to start the cheese flying sequence.
    public bool cheeseFlying = false; //Switch. Is the cheese flying?


    private int playerNumber;

    

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = gameObject.GetComponent<PlayerMovement>().playerNumber;
        catapult = GameObject.Find("catapult");
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPress == true)
        {
            //if the colcheck contains any object
            if (colcheck != null)
            {
                cheeseFlying = true;
            }
            
        }

        if (cheeseFlying == true)
        {
            //mount position is defined
            mountpos = GameObject.FindGameObjectWithTag("Mounts").transform.position;

            //Physics2D.IgnoreCollision = false;
            //gameObject.GetComponent<Rigidbody2D>().GetComponent<> = false;
            //Physics2D.IgnoreCollision(gameObject.GetComponent<PolygonCollider2D>(), GameObject.FindGameObjectWithTag("Walls").GetComponent<TileMapCollider2D>());

            //Colliders are set to triggers to avoid collision with walls while flying. One of these probably need to be deleted when we figure out what collider we'll use.
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;

            //Cheese is moved towards the cat
            gameObject.transform.position = Vector3.MoveTowards(transform.position, mountpos, catapultedSpeed * Time.deltaTime);

            //Check whether Cheese has arrived to cat / mount
            if (gameObject.transform.position.x == mountpos.x && gameObject.transform.position.y == mountpos.y)
            {
                if (cheeseFlying == true)
                {
                    //colcheck no longer contains the collision between catapult and cheese.
                    colcheck = null;
                    //GameObject mountObject = GameObject.FindGameObjectWithTag("Mounts");

                    
                    //PlayerMounting() funktionen i PlayerMovement scriptet kaldes
                    gameObject.GetComponent<PlayerMovement>().PlayerMounting();
                }
            }
        }

        //Catapult launch trigger on when pressed
        if (Input.GetAxis("P" + playerNumber + "_Activate") > 0)
        {
            buttonPress = true;
        }

        //Catapult launch trigger off when released
        if(Input.GetAxis("P" + playerNumber + "_Activate") < 0)
        {
            buttonPress = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if collision object has the catapult tag
        if (collision.gameObject.tag.Equals("catapult") == true)
        {
            //Check if this gameobject is a cheese
            if (gameObject.tag.Equals("Cheese"))
            {
                colcheck = collision.gameObject;
            }
        }
    }
}
