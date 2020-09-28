using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5f;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float p1_MoveHorizontal = Input.GetAxis("P1_Horizontal");
        float p1_MoveVertical = Input.GetAxis("P1_Vertical");
        float p2_MoveHorizontal = Input.GetAxis("P2_Horizontal");
        float p2_MoveVertical = Input.GetAxis("P2_Vertical");
        
        Vector3 p1_movement = new Vector3(p1_MoveHorizontal, p1_MoveVertical, 0f);
        
        transform.Translate(p1_movement * Time.deltaTime * movementSpeed);
        
    }
    
    
   
}
