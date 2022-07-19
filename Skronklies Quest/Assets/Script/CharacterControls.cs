using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpVelocity = 10f;

    public int health = 3;

    public Transform carrySpot;
    bool carryObject = false;
    GameObject carry = null;
    bool facingRight = true;

    Rigidbody2D rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }


    void Update()
    {
        characterMovement();

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
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            facingRight = false;
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(+movementSpeed, rb.velocity.y);
                facingRight = true;
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
        carryObject = false;
        Rigidbody2D rb = carry.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        if(facingRight)
            carry.transform.position = transform.position + new Vector3(1.5f, 0, 0);
        else
            carry.transform.position = transform.position - new Vector3(1.5f, 0, 0);
    }

    
}
