using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        int setup = Random.Range(1, 8);
        if (setup < 3)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            timer = Random.Range(5, 15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.timer == 0)
        {
            this.gameObject.SetActive(false);
        }
        else if (this.timer < Time.deltaTime)
        {
            this.timer = 0;
        }
        else
        {
            this.timer -= Time.deltaTime;
        }
    }
}
