using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public bool CanPickUp;
    public GameObject pickUpObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.layer);
        CanPickUp = collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0);
        pickUpObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanPickUp = false;
        pickUpObject = null;
    }
}
