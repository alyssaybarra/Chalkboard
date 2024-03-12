using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript2 : MonoBehaviour
{
    public GameObject musicInitial;
    AudioSource musicSource;
    bool hasStarted = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted) 
        {
            if (timer == 0)
            {
                if (!musicSource.loop)
                {
                    musicSource.Play();
                    musicSource.loop = true;

                }
            }
            else if (timer < Time.deltaTime)
            {
                timer = 0;
            }
            else 
            { 
                timer -= Time.deltaTime;
                if (timer < 1f)
                {
                    musicInitial.GetComponent<AudioSource>().loop = false;
                    musicInitial.GetComponent<AudioSource>().Stop();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        hasStarted = true;
        timer = 1.5f;

    }
}
