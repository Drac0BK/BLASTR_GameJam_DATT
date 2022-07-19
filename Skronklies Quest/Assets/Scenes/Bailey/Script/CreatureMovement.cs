using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    int direction = 0;
    float movementSpeed = 1.0f;
    Rigidbody2D rb = null;

    float timer = 3.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Random.Range(0, 2);
    }

    private void Update()
    {
        if (transform.parent == null)
        {
            if (direction == 0)
            {
                rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
            }
            else if (direction == 1)
            {
                rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

            }
        }
        else
        {
            Debug.Log(timer);
            timer-= Time.deltaTime;
            rb.velocity = new Vector2(0,rb.velocity.y);
            if(timer < 0 )
            {
                transform.position = transform.parent.position + new Vector3(1.5f, 0, 0);
                transform.parent = null;
                rb.isKinematic = false;
                //to go in the opposite direction than intitially //rb.velocity = -rb.velocity;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (direction == 0)
        {
            direction = 1;
            Debug.Log("Hity");
        }
        else if (direction == 1)
        {
            direction = 0;
            Debug.Log("hurty");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.name == "Player")
        {
            Debug.Log("IT WORKS");
        }
    }
}
