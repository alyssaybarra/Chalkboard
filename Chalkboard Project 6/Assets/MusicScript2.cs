using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript2 : MonoBehaviour
{
    public GameObject musicInitial;
    AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        this.musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        musicInitial.GetComponent<AudioSource>().loop = false;
        musicInitial.GetComponent<AudioSource>().Stop();
        musicSource.Play();
        musicSource.loop = true;

    }
}
