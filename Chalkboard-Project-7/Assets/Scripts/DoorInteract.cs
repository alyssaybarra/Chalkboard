using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteract : MonoBehaviour
{
    public TextMeshProUGUI textField;

    [TextArea(3, 3)]
    public string[] dialogueLines;

    int currentDialogueIdx;

    private void Start()
    {
        textField.text = "";
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && dialogueLines.Length > 0)
        {
            RunDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textField.text = "";
    }

    private void RunDialogue()
    {
        if (currentDialogueIdx < dialogueLines.Length)
        {
            textField.text = dialogueLines[currentDialogueIdx];
            currentDialogueIdx++;
        }
        else
        {
            currentDialogueIdx = 0;
            textField.text = "";
        }
    }
}
