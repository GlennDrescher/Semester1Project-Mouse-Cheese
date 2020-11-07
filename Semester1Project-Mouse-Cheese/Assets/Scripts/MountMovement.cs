using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountMovement : MonoBehaviour
{

// -------====== Public Variables ======-------

    // Change the speed of the character
    public float moveSpeed = 15f;
    public float rotationSpeed = 200f; // Rotation Speed in degrees per second

    // is the player mounted to another actor, like the cheese is mounted on the cat?
    public bool mounted = false; // Not used yet



    // -------====== Private Variables ======-------

    // Created the Variables here so they are accessible everywhere and only changed up update
    // it gives a performance increase if the variables are only changed instead of created new ones every frame
    private float moveHorizontal;
    private float moveVertical;
    private readonly float diagonalMovementModifier = 0.7f; // Modifies the diagonal movement speed

    // Saved the objects rigid body, it will change if fx. it is mounted something.
    public Rigidbody2D body;


    // -------====== Update Functions ======-------

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    }




    // -------====== Movement Functions ======-------




}
