using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform portalLocation;
    public GameObject portal;

    public Spinner portalSpin;
    public Light portalLight;

    private float sizeMult = 1;
    private float itemsCollected = 0;

    private GameObject targetObj;
    private Vector3 originalScale;

    private bool updateScale = false;

    private void Start()
    {
        originalScale = portal.transform.localScale;
    }

    private void Update()
    {
        if (targetObj != null)
        {
            targetObj.transform.position = Vector3.Lerp(targetObj.transform.position, portalLocation.position, Time.deltaTime);
            if (Vector3.Distance(portalLocation.position, targetObj.transform.position) < 0.5f)
            {
                Destroy(targetObj);
                targetObj = null;
                sizeMult += 0.2f;
                itemsCollected++;
                updateScale = true;
                if (itemsCollected >= 3)
                {
                    UpdatePortal();
                }
            }
        }
        if (updateScale)
        {
            portal.transform.localScale = Vector3.Lerp(portal.transform.localScale, originalScale * sizeMult, Time.deltaTime * 2);
            if (Vector3.Distance(portal.transform.localScale, originalScale * sizeMult) < 0.01f)
            {
                portal.transform.localScale = originalScale * sizeMult;
                updateScale = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SendToPortal")
        {
            targetObj = other.gameObject;

            Moveable.currentlyHeld = null;
            Destroy(targetObj.GetComponent<Moveable>());
            Destroy(targetObj.GetComponent<Rigidbody>());
            Destroy(targetObj.GetComponent<Collider>());
        }       
    }

    private void UpdatePortal()
    {
        portalSpin.speedMult = 2;
        portalLight.intensity = 16;
    }
}
