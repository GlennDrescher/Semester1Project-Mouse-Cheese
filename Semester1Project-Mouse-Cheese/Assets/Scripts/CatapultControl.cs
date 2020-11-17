using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatapultControl : MonoBehaviour

{
    private GameObject colcheck = null;
    private GameObject catapult;
    private Vector2 mountpos;
    public float catapultedSpeed = 5;
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
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.transform.position = Vector3.MoveTowards(transform.position, mountpos, catapultedSpeed * Time.deltaTime);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("djdjd");
        if (collision.gameObject.tag.Equals("catapult") == true)
        {
            Debug.Log("Virker det her??");
            

            
            

            if (gameObject.tag.Equals("Cheese"))
            {

                colcheck = collision.gameObject;





                Debug.Log("Test");

            }
            
        }
        if (collision.gameObject.tag.Equals("Mounts") == true)
        {
            if (cheeseFlying == true)
            { 
                colcheck = null;
                cheeseFlying = false;
                Debug.Log("Variables should be disabled.");
                gameObject.GetComponent<PlayerMovement>().isMounting = true;
            }
        }
       
    }
    
    

    /*IEnumerator charMove()
    {
        charCheck = OnCollision2D()

    }*/
    


}
