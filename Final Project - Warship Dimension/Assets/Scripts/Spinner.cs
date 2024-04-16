using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 angles = this.transform.rotation.eulerAngles;
        this.transform.rotation = Quaternion.Euler(angles.x, angles.y, angles.z + (-80 * Time.deltaTime));
    }
}
