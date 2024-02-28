using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeTextTrigger : MonoBehaviour
{
    [TextArea(3, 3)]
    public string text;
    public NarrativeDisplay narrativeCanvas;

    private bool displayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!displayed)
        {
            narrativeCanvas.DisplayText(text);
            displayed = true;
        }
    }
}
