using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    float timer = 1.0f;
    int direction = 0;
    float movementSpeed = 1.0f;
    Rigidbody2D rb = null;

    [SerializeField]
    BoxCollider2D collider1 = null;
    [SerializeField]
    BoxCollider2D collider2 = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Random.Range(0, 2);
        if (direction == 0)
        {
            collider1.enabled = false;
        }
        else if (direction == 1)
        {
            collider2.enabled = false;
        }
    }

    private void Update()
    {
        if(transform.parent == null)
        {
            if(direction == 0)
            {
                rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
                collider2.enabled = true;
                collider1.enabled = false;
            }
            else if (direction == 1)
            {
                rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
                collider1.enabled = true;
                collider2.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
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
}
