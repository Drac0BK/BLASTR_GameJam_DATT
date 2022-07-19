using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public bool CanPickUp;
    public bool CanDropObject;
    public GameObject pickUpObject;

    public BoxCollider2D pick1, pick2;

    public void Update()
    {
        if(transform.parent.GetComponent<CharacterControls>().facingRight)
        {
            pick1.enabled = false;
            pick2.enabled = true;
        }
        else
        {
            pick1.enabled = true;
            pick2.enabled = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision)
        //Debug.Log(collision.gameObject.layer);
        CanPickUp = collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0);
        CanDropObject = false;
        pickUpObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanPickUp = false;
        CanDropObject = true;
        pickUpObject = null;
    }
}
