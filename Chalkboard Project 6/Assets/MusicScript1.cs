using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MusicScript1 : MonoBehaviour
{
    public GameObject musicSecond;
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
    private void OnTriggerEnter(Collider other)
    {
        if (this.musicSecond.GetComponent<AudioSource>().loop)
        {
            this.musicSecond.GetComponent<AudioSource>().Stop();
            this.musicSecond.SetActive(false);
            this.musicSource.Stop();
            this.gameObject.SetActive(false);
        }
    }
}
