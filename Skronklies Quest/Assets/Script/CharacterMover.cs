using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    // Update is called once per frame
    private float movementSpeed = 5f;
    private float jumpVelocity = 10f;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        characterMovement();

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //update the position
        //transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded() || Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

    }

    private bool IsGrounded() { return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded; }

    void characterMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(+movementSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

}
