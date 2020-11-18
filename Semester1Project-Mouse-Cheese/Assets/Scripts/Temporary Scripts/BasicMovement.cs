using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private float playerSpeed = 2.0f;
    private Rigidbody2D control;

    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        control = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("P1_Horizontal"), Input.GetAxis("P1_Vertical"));
        //control.1(move * Time.deltaTime * playerSpeed);
        if (move != Vector2.zero)
        {
            gameObject.transform.forward = move;
        }
    
    }
}
