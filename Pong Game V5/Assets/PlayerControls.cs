using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //input offset
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    //paddle moveing speed
    public float speed = 10.0f;

    //the highest position where the paddle can move to
    public float boundX = 4.45f;

    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //reference to Rigidbody
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //initial setup Rigidbody2D
        rb2d = GetComponent < Rigidbody2D >();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }

        var vel = rb2d.velocity;

        if (Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }

        else if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }

        else
        {
            vel.x = 0;
        }

        rb2d.velocity = vel;
        
        var pos = transform.position;

        if(pos.x > boundX)
        {
            pos.x = boundX;
        }

        else if(pos.x < -boundX)
        {
            pos.x = -boundX;
        }

        transform.position = pos;
    }
}
