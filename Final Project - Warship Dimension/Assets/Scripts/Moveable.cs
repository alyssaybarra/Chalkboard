using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public static GameObject currentlyHeld;

    public float pickupRadius;
    public Transform holder;

    [HideInInspector] public bool pickedUp;
    private Collider col;
    private Rigidbody rb;

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
        col = gameObject.GetComponent<Collider>();
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
            if (transform.position.y < -5)
            {
                transform.position = originalPos;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
