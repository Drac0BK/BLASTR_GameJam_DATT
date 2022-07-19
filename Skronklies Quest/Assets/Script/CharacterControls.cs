using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterControls : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpVelocity = 10f;
    [SerializeField] private Animator skronkMover;

    public int health = 3;

    public GameObject skronkly;
    public Transform respawnPos;
    public Transform respawnPos2;
    public Transform carrySpot;
    public bool carryObject = false;
    GameObject carry = null;
    bool facingRight = true;

    Rigidbody2D rb;

    public float lifeTimer = 10.0f;

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

        lifeTimer -= Time.deltaTime;

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
        skronkMover.SetBool("Moving", false);
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
        skronkMover.SetBool("Moving", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathTrigger")
        {
            transform.position = respawnPos.transform.position;
            skronkly.transform.position = respawnPos2.transform.position;
        }
    }

}
