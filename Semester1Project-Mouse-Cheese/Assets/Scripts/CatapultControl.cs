using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatapultControl : MonoBehaviour

{
    private bool colcheck;
    private GameObject catapult;
    private Vector2 mountpos;
    public float catapultedSpeed = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        catapult = GameObject.Find("catapult");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("djdjd");
        if (collision.gameObject.tag.Equals("catapult") == true)
        {
            Debug.Log("Virker det her??");
            
            
            
            if (gameObject.tag.Equals("Cheese"))
            {
                
                
            }
            
        }
    }
    private void CatapultLaunch()
    {
        mountpos = GameObject.FindGameObjectWithTag("Mounts").transform.position;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;



        transform.position = Vector2.MoveTowards(transform.position, mountpos, catapultedSpeed * Time.deltaTime);



        Debug.Log("Test");
    }


}
