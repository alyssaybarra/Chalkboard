using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamDetection : MonoBehaviour
{
    [SerializeField]
    TalkingScript talkingScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        talkingScript.setOption(2, true);
    }
}
