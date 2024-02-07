using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaternions : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LookAtMe()
    {
        Vector3 offset = target.position - transform.position;
        offset.Normalize();

        Vector3 axis = Vector3.Cross(transform.forward, offset);
        axis.Normalize();

        // angle in radians
        float angle = Mathf.Acos(Vector3.Dot(transform.forward, offset));

        Quaternion q = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, axis);

        transform.rotation *= q;




    }
}
