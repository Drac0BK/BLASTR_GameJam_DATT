using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public bool CanPickUp;

    private void OnTriggerStay2D(Collider2D collision)
    {
        CanPickUp = collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanPickUp = false;
    }
}
