using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    public float speed;
    public float rotationAmount = 180;

    private bool turning = false;
    private Vector3 startDirection;
    private Vector3 targetDirection;
    private float percentageDone = 0;
    private float currentSpeed;

    private bool moved = false;


    void OnTriggerStay(Collider col)
    {
        if (!moved && !turning && Input.GetMouseButtonDown(0) && col.tag == "CannonDetector")
        {
            startDirection = transform.eulerAngles;
            targetDirection = transform.eulerAngles + new Vector3(0, rotationAmount, 0);
            currentSpeed = speed;
            turning = true;
            moved = true;
            percentageDone = 0;
        }
    }

    private void Update()
    {
        if (turning)
        {
            if (percentageDone >= 0.98)
            {
                transform.eulerAngles = targetDirection;
                turning = false;
            }
            else
            {
                transform.eulerAngles = Vector3.Lerp(startDirection, targetDirection, percentageDone);
                percentageDone += Time.deltaTime * currentSpeed;
                currentSpeed = speed * (1 + percentageDone);
            }
            
        }
    }
}
