using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeDisplay : MonoBehaviour
{
    public float displayTime;
    public TextMeshProUGUI textBox;

    private bool displaying;
    private float currentTimer;

    public void DisplayText(string narrative)
    {
        textBox.text = narrative;
        currentTimer = displayTime;
        displaying = true;
    }

    void Update()
    {
        if (!displaying)
        {
            return;
        }

        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else
        {
            currentTimer = 0;
            textBox.text = "";
            displaying = false;
        }
    }
}
