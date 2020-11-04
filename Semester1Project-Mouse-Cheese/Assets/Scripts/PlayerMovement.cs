using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

// -------====== Public Variables ======-------

    // What kind is the player? is it a cheese or a Mouse?
    public PlayerType playerType = PlayerType.Mouse;

    // Defines which player it is.
    // Maps the correct input to the gameObject
    public int playerNumber = 1;

    // Change the speed of the character
    public float moveSpeed = 15f;
    public float rotationSpeed = 200f; // Rotation Speed in degrees per second
    public bool usingLocalControl = false;
    
    // is the player mounted to another actor, like the cheese is mounted on the cat?
    public bool isMounting = false; // Not used yet




// -------====== Private Variables ======-------

    // Created the Variables here so they are accessible everywhere and only changed up update
    // it gives a performance increase if the variables are only changed instead of created new ones every frame
    private float moveHorizontal;
    private float moveVertical;
    private readonly float diagonalMovementModifier = 0.7f; // Modifies the diagonal movement speed

    // Saved the objects rigid body
    private Rigidbody2D body;


    // Activating and Mounting
    private GameObject closeToActivatable = null;



// -------====== Flow Functions ======-------

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        closeToActivatable = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closeToActivatable = null;
    }




    // -------====== Update Functions ======-------

    // Update is called once per frame
    void Update()
    {
        // Check every frame for key input and update the variables

        UpdateMoveAxis();

        if (closeToActivatable != null)
        {
            if (!isMounting)
            {
                PlayerMounting();
            }

        }

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().simulated = !isMounting;
        if (!isMounting)
        {

            // Move the rigidBody according to move... Variables
            if (usingLocalControl)
            {
                MovePlayerWithLocalControl();
            }
            else
            {
                MovePlayerWithWorldSpaceControl();
            }
        }
    }




// -------====== Movement Functions ======-------

    // Simply gets the input values and updates the variables in realtime depending on the playerNumber
    void UpdateMoveAxis()
    {
        if (!isMounting)
        {
            moveHorizontal = Input.GetAxis("P" + playerNumber + "_Horizontal");
            moveVertical = Input.GetAxis("P" + playerNumber + "_Vertical");
        }
    }


    // Moves and rotates the player depending on the input in Worldspace
    void MovePlayerWithWorldSpaceControl()
    {

        // Check for diagonal Movement
        if (moveHorizontal != 0 && moveVertical != 0)
        {
            // Modify diagonal movement speed
            moveHorizontal *= diagonalMovementModifier;
            moveVertical *= diagonalMovementModifier;
        }

        // Move player according to input direction
        body.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);

        // rotate player towards movement direction
        if (body.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;
            Quaternion deltaRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, deltaRotation, rotationSpeed * Time.deltaTime);
            //body.MoveRotation(body.rotation + rotationSpeed * Time.fixedDeltaTime);
            body.MoveRotation(rotation);
        }
    }


    // Moves and rotates the player depending on the input around objects axis
    void MovePlayerWithLocalControl()
    {
        Vector2 direction = new Vector2(transform.right.x, transform.right.y);
        //body.velocity = direction * moveVertical * moveSpeed;
        body.AddForce(direction * moveVertical * moveSpeed * 50);

        // body.AddTorque((moveHorizontal * -1) * rotationSpeed); // angularVelocity works snappier than Add.Torque
        //body.angularVelocity = moveHorizontal * -1 * rotationSpeed;
        body.AddTorque(moveHorizontal * -1 * rotationSpeed);
    }



// -------====== Mounting Functions ======-------

    void PlayerMounting()
    {

        // If Cheese is close to cat
        if (Input.GetAxis("P" + playerNumber + "_Activate") == 1
            && playerType == PlayerType.Cheese)
        {
            isMounting = true;
            transform.position = closeToActivatable.transform.position;
        }
    }

    void PlayerDismounting()
    {
        if (Input.GetAxis("P" + playerNumber + "_Activate") == 1
                    && playerType == PlayerType.Cheese)
        {
            isMounting = false;
            transform.position = new Vector3(0, 0, 0);
        }
    }



    // -------====== Constructor Functions ======-------

    // Initial setup of the player and its variables
    void InitializePlayer()
    {
        body = GetComponent<Rigidbody2D>();

        // Assigns the right textures as sprite depending on inspector settings of the player type
        AssignTextureSprite();
    }

    // Assigns the right textures as sprite depending on inspector settings of the player type
    // Could be changed when the playertype is defined by a Class instead
    void AssignTextureSprite()
    {
        if (playerType == PlayerType.Cheese)
        {
            gameObject.tag = "Cheese";
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Actors/cheese", typeof(Sprite)) as Sprite;
        } else
        {
            gameObject.tag = "Mouse";
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Actors/mouse", typeof(Sprite)) as Sprite;
        }
    }
}


// Defines the player type
// Could be changed in something like a class that predifines stuff like movement speed, textures, functionality etc.
public enum PlayerType
{
    Cheese,
    Mouse
}
