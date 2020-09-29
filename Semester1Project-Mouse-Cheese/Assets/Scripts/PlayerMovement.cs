using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // -------====== Public Variables ======-------

    // What kind is the player? is it a cheese or a Mouse?
    public PlayerType playerType = PlayerType.Mouse;

    // Defines what player it is.
    public int playerNumber = 1;

    // Change the speed of the character
    public float movementSpeed = 5f;
    
    // is the player mounted to another actor, like the cheese is mounted on the cat?
    public bool isMounted = false;





    // -------====== Private Variables ======-------

    private string input_Horizontal;
    private string input_Vertical;





    // -------====== Functions ======-------

    // Start is called before the first frame update
    void Start()
    {
        assignInputAccordingToPlayerNumber();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        
        
    }

    void movePlayer()
    {
        float moveHorizontal = Input.GetAxis(input_Horizontal);
        float moveVertical = Input.GetAxis(input_Vertical);

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        transform.Translate(movement * Time.deltaTime * movementSpeed);
    }

    void assignInputAccordingToPlayerNumber()
    {
        input_Horizontal = "P" + playerNumber + "_Horizontal";
        input_Vertical = "P" + playerNumber + "_Vertical";
    }
    
    
   
}

public enum PlayerType
{
    Cheese,
    Mouse
}
