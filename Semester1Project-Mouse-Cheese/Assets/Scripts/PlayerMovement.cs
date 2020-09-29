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
    public float moveSpeed = 15f;
    public float rotationSpeed = 180f;
    
    // is the player mounted to another actor, like the cheese is mounted on the cat?
    public bool isMounted = false; // Not used yet


    // -------====== Private Variables ======-------

    // Created the Variables here so they are accessible everywhere and only changed up update
    // it gives a performance increase if the variables are only changed instead of created new ones every frame
    private float moveHorizontal;
    private float moveVertical;
    private float diagonalMovementModifier = 0.7f;

    // Saved the objects rigid body
    private Rigidbody2D body;


    // -------====== Functions ======-------

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        // Check every frame for key input and update the variables
        UpdateMoveAxis();
    }

    private void FixedUpdate()
    {
        // Move the rigidBody according to move... Variables
        MovePlayer();
    }

    void UpdateMoveAxis()
    {
        moveHorizontal = Input.GetAxis("P" + playerNumber + "_Horizontal");
        moveVertical = Input.GetAxis("P" + playerNumber + "_Vertical");
    }

    void MovePlayer()
    {
        if (moveHorizontal != 0 && moveVertical != 0) // Check for Vertical Movement
        {
            // move slower diagonal
            moveHorizontal *= diagonalMovementModifier;
            moveVertical *= diagonalMovementModifier;
        }
        // Move player accordingly
        body.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
    }

    void InitializePlayer()
    {
        body = GetComponent<Rigidbody2D>();

        AssignTextureSprite();
    }

    void AssignTextureSprite()
    {
        if (playerType == PlayerType.Cheese)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Actors/cheese", typeof(Sprite)) as Sprite;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Actors/mouse", typeof(Sprite)) as Sprite;
        }
    }
}

public enum PlayerType
{
    Cheese,
    Mouse
}
