using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Mount Movement based on: https://www.youtube.com/watch?v=5owq_9lptdE&ab_channel=gamesplusjames
/// </summary>

public class MountMovement : MonoBehaviour
{
    // -------====== Public Variables ======-------

    public bool isMounted = false;
    public bool isMoving = true;

    public float moveSpeed = 25f;
    public float rotationSpeed = 200f;



    // -------====== Private Variables ======-------

    // Created the Variables here so they are accessible everywhere and only changed up update
    // it gives a performance increase if the variables are only changed instead of created new ones every frame
    private float moveHorizontal;
    private float moveVertical;
    private readonly float diagonalMovementModifier = 0.7f; // Modifies the diagonal movement speed

    // Saved the objects rigid body
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        InvokeRepeating("RandomMovement", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once every 0.02seconds, mostly for physics
    private void FixedUpdate()
    {
        // Move the rigidBody according to move... Variable
        MoveMount();
    }

    float randomNumber(float min, float max)
    {
        return moveHorizontal = Random.Range(min, max);
    }

    void RandomMovement()
    {
        moveHorizontal = randomNumber(-1, 1) * (Time.fixedDeltaTime * 50);
        moveVertical = randomNumber(-1, 1) * (Time.fixedDeltaTime * 50);
    }

    void MoveMount()
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
            body.MoveRotation(rotation);
        }
    }
}

