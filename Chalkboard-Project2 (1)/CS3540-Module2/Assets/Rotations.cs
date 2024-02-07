using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(30,45,15);
        //transform.Rotate(Vector3.up, 45);

        Quaternion q;

        q = Quaternion.AngleAxis(45, Vector3.up);

        //Debug.Log("Quaternion: " + q);

        Quaternion q2 = Quaternion.AngleAxis(45, Vector3.up);

        transform.rotation = q * q2;

        q2 = Quaternion.Euler(30, 45, 15);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
