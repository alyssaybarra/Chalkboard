using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public float timer;

    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        int setup = Random.Range(1, 8);
        light.enabled = setup > 4;

        timer = Random.Range(10, 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (this.timer <= 0)
        {
            if (light.enabled)
            {
                light.enabled = false;
                timer = Random.Range(20, 40);
            }
            else
            {
                light.enabled = true;
                timer = Random.Range(5, 15);
            }
        }
    }
}
