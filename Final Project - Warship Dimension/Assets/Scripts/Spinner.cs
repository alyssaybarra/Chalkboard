using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public bool xSpin;
    public bool ySpin;
    public bool zSpin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.identity;

        if (xSpin)
        {
            rotation *= Quaternion.Euler(-80 * Time.deltaTime, 0, 0);
        }    
        else if (ySpin)
        {
            rotation *= Quaternion.Euler(0, -80 * Time.deltaTime, 0);
        } 
        else if (zSpin)
        {
            rotation *= Quaternion.Euler(0, 0, -80 * Time.deltaTime);
        }
            
        transform.rotation *= rotation;
    }
}
