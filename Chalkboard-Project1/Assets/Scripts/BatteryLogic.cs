using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLogic : MonoBehaviour
{
    public GameObject FlashlightController;
    public GameObject Player;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,Player.transform.position) < 10) {
            rb.AddForce((Player.transform.position -transform.position) * 10f, ForceMode.Force);
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name == Player.name) {
            FlashlightController.GetComponent<FlashlightController>().PickupBattery();
            Destroy(gameObject);
        }
    }
}
