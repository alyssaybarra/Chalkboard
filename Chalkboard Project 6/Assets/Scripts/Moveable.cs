using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public static GameObject currentlyHeld;

    public float pickupRadius;
    public Transform holder;

    private bool pickedUp;
    private BoxCollider col;
    private Rigidbody rb;

    private void Start()
    {
        col = gameObject.GetComponent<BoxCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            Vector3.Distance(transform.position, holder.position) < pickupRadius)
        {
            // if the player is currently holding something else, cancel
            if (currentlyHeld != null && currentlyHeld != gameObject)
            {
                return;
            }

            col.enabled = pickedUp;
            rb.useGravity = pickedUp;
            pickedUp = !pickedUp;
            currentlyHeld = pickedUp ? gameObject : null;

            transform.position = holder.position;
            transform.eulerAngles = Vector3.zero;
        }

        if (pickedUp)
        {
            transform.parent = holder;
        }
        else
        {
            transform.parent = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
