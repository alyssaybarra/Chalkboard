using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        int setup = Random.Range(1, 8);
        this.gameObject.SetActive(setup > 4);

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
            if (gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                timer = Random.Range(20, 40);
            }
            else
            {
                this.gameObject.SetActive(true);
                timer = Random.Range(5, 15);
            }
        }
    }
}
