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
    public float rotationSpeed = 200f;   // Rotation Speed in degrees per second
    public bool usingLocalControl = false;

    public float mountedMoveSpeed;
    public float mountedRotationSpeed;
    



// -------====== Private Variables ======-------

    // Created the Variables here so they are accessible everywhere and only changed up update
    // it gives a performance increase if the variables are only changed instead of created new ones every frame
    private float moveHorizontal;
    private float moveVertical;
    private readonly float diagonalMovementModifier = 0.7f; // Modifies the diagonal movement speed

    // Saved the objects rigid body, it will change if fx. it is mounted something.
    public Rigidbody2D body;


    // Activating and Mounting
    private GameObject closeToActivatable = null;

    private bool mounted = false; // is the player mounted to another actor, like the cheese is mounted on the cat?
    private GameObject mountedTo = null;



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

        if (closeToActivatable != null && closeToActivatable.CompareTag("Mounts"))
        {
            if (!mounted)
            {
                PlayerMounting();
            }

        }


        // If Mounted the cheese follows the cat
        if (mounted)
        {
            transform.position = mountedTo.transform.position;
            transform.rotation = mountedTo.transform.rotation;
        }

    }

    private void FixedUpdate()
    {
        // Move the rigidBody according to move... Variables
        if (usingLocalControl)
        {
            MoveObjectWithLocalControl();
        }
        else
        {
            MoveObjectWithWorldSpaceControl();
        }
    }




// -------====== Movement Functions ======-------

    // Simply gets the input values and updates the variables in realtime depending on the playerNumber
    void UpdateMoveAxis()
    {
        if (gameObject.GetComponent<CatapultControl>().cheeseFlying == false)
        {
            moveHorizontal = Input.GetAxis("P" + playerNumber + "_Horizontal");
            moveVertical = Input.GetAxis("P" + playerNumber + "_Vertical");
        }

        
    }


    // Moves and rotates the player depending on the input in Worldspace
    void MoveObjectWithWorldSpaceControl()
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
            Quaternion rotation = Quaternion.RotateTowards(body.gameObject.transform.rotation, deltaRotation, rotationSpeed * Time.deltaTime);
            //body.MoveRotation(body.rotation + rotationSpeed * Time.fixedDeltaTime);
            body.MoveRotation(rotation);
        }
    }


    // Moves and rotates the player depending on the input around objects axis
    void MoveObjectWithLocalControl()
    {
        body.AddForce(body.transform.right * moveVertical * moveSpeed * 850);
        body.AddTorque(moveHorizontal * -1 * rotationSpeed * 100);
    }



// -------====== Mounting Functions ======-------

    public void PlayerMounting()
    {

        // If Cheese is close to cat or if the cheese is flying
        if (Input.GetAxis("P" + playerNumber + "_Activate") == 1
            && playerType == PlayerType.Cheese
            || playerType == PlayerType.Cheese && gameObject.GetComponent<CatapultControl>().cheeseFlying == true)
            //gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        {
            Debug.Log("Funktionen køres");
            mounted = true;
            if (mounted == true)
            {
                Debug.Log("mount er sandt");
            }
            mountedTo = closeToActivatable;
            if (mountedTo == closeToActivatable)
            {
                Debug.Log("mountTo virker");
            }
            GetComponent<Rigidbody2D>().simulated = false;
            if (GetComponent<Rigidbody2D>().simulated == false)
            {
                Debug.Log("simulated-ness virker");
            }
            body = mountedTo.GetComponent<Rigidbody2D>();
            if(body == mountedTo.GetComponent<Rigidbody2D>())
            {
                Debug.Log("body variabel virker");
            }
            gameObject.GetComponent<CatapultControl>().cheeseFlying = false;
        }

    }


    // !!!! NOT WORKING
    void PlayerDismounting()
    {
        mounted = false;
        body = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, 0, 0);
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }



    // -------====== Constructor Functions ======-------

    // Initial setup of the player and its variables
    void InitializePlayer()
    {
        body = GetComponent<Rigidbody2D>();


        if (usingLocalControl)
        {
            moveSpeed *= 1;
            rotationSpeed *= 1;

            mountedMoveSpeed = moveSpeed * 2;
            mountedRotationSpeed = rotationSpeed;
        } else if (!usingLocalControl)
        {
            moveSpeed *= 1;
            rotationSpeed *= 1;

            mountedMoveSpeed = moveSpeed * 2;
            mountedRotationSpeed = rotationSpeed * 2;
        }

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


        gameObject.AddComponent<PolygonCollider2D>();
        gameObject.AddComponent<CompositeCollider2D>();
    }
}


// Defines the player type
// Could be changed in something like a class that predifines stuff like movement speed, textures, functionality etc.
public enum PlayerType
{
    Cheese,
    Mouse
}
