using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class CharacterControls : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpVelocity = 10f;
    [SerializeField] private Animator skronkMover;

    private Animator playerAnimator;
    public Slider slider;

    public AudioSource jump;

    public int health = 3;

    public GameObject skronkly;
    public Transform respawnPos;
    public Transform respawnPos2;
    public Transform carrySpot;
    public bool carryObject = false;
    GameObject carry = null;
    public bool facingRight = true;

    Rigidbody2D rb;

    public float lifeTimer = 10.0f;
    public bool inSafety = false;

    private float startFogAlpha = 0f, shrinkFogAlpha = 0f;

    [SerializeField]
    private SpriteRenderer fog, fogBackground;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        slider.maxValue = 10;
        slider.minValue = 0;
        slider.value = lifeTimer;

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        fog.color = new Color(1, 1, 1, startFogAlpha);
        fogBackground.color = new Color(1, 1, 1, startFogAlpha);
    }


    void Update()
    {
        playerAnimator.SetBool("IsGrounded", IsGrounded());
        slider.value = lifeTimer;
        characterMovement();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded() || Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            jump.Play();
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if(CanPickUp() && Input.GetKeyDown(KeyCode.E) && carryObject == false)
        {
            PickUpObject();
        }
        if (Input.GetKeyDown(KeyCode.Q) && carryObject == true && CanDropObject())
        {
            DropObject();
        }
        playerAnimator.SetBool("IsCarrying", carryObject);
        if(!inSafety)
        {
            lifeTimer -= Time.deltaTime;

            shrinkFogAlpha = (-lifeTimer/10) + 1;
            fog.color = new Color(1, 1, 1, shrinkFogAlpha);
            fogBackground.color = new Color(1, 1, 1, shrinkFogAlpha);

        }
        else
        {
            fog.color = new Color(1, 1, 1, startFogAlpha);
            fogBackground.color = new Color(1, 1, 1, startFogAlpha);
        }

        if(lifeTimer < 0)
        {
            transform.position = respawnPos.transform.position;
            skronkly.transform.position = respawnPos2.transform.position;
            skronkly.transform.parent = null;
            skronkly.GetComponent<Rigidbody2D>().isKinematic = false;
            skronkMover.SetBool("Moving", true);
            carryObject = false;
            lifeTimer = 10.0f;
        }
    }

    private bool IsGrounded() { return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded; }
    private bool CanPickUp() { return transform.Find("PickUpCheck").GetComponent<PickUpObjectCheck>().CanPickUp; }

    private bool CanDropObject() { return transform.Find("PickUpCheck").GetComponent<PickUpObjectCheck>().CanDropObject; }

    void characterMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnimator.SetBool("IsMoving", true);
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            facingRight = false;
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                playerAnimator.SetBool("IsMoving", true);
                rb.velocity = new Vector2(+movementSpeed, rb.velocity.y);
                facingRight = true;
            }
            else
            {
                playerAnimator.SetBool("IsMoving", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        playerAnimator.SetBool("IsRight", facingRight);
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
        Debug.Log(CanDropObject());
        if(facingRight)
            carry.transform.position = transform.position + new Vector3(0.5f, 0, 0);
        else
            carry.transform.position = transform.position - new Vector3(0.5f, 0, 0);
        skronkMover.SetBool("Moving", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathTrigger")
        {
            transform.position = respawnPos.transform.position;
            skronkly.transform.position = respawnPos2.transform.position;
            skronkly.transform.parent = null;
            skronkly.GetComponent<Rigidbody2D>().isKinematic = false;
            skronkMover.SetBool("Moving", true);
            carryObject = false;
        }
    }
    public void Shmoving()
    {
        skronkMover.SetBool("Moving", true);
    }
    
}
