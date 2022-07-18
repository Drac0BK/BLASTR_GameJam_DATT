using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    // Update is called once per frame
    private float movementSpeed = 5f;
    private float jumpVelocity = 10f;

    public Transform carrySpot;
    bool carryObject = false;
    GameObject carry = null;

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

        if(CanPickUp() && Input.GetKeyDown(KeyCode.E) && carryObject == false)
        {
            PickUpObject();
        }
        if (Input.GetKeyDown(KeyCode.Q) && carryObject == true)
        {
            DropObject();
        }
    }

    private bool IsGrounded() { return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded; }
    private bool CanPickUp() { return transform.Find("PickUpCheck").GetComponent<PickUpObjectCheck>().CanPickUp; }
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

    void PickUpObject()
    {
        carry = GameObject.Find("PickUpCheck").GetComponent<PickUpObjectCheck>().pickUpObject;
        carry.transform.parent = transform;
        carry.transform.position = carrySpot.transform.position;
        Rigidbody2D rb = carry.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        carryObject = true;
    }

    void DropObject()
    {
        carry.transform.parent = null;
        carry.transform.position = transform.position + Vector3.right + Vector3.right;
        carryObject = false;
        Rigidbody2D rb = carry.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }

}
