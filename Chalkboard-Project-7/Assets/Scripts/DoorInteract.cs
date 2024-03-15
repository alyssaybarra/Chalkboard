using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteract : MonoBehaviour
{
    public TextMeshProUGUI textField;

    [TextArea(3, 3)]
    public string[] dialogueLines;
    public Animator animator;

    private int currentDialogueIdx;

    private bool sliderOpen = false;

    private void Start()
    {
        textField.text = "";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueLines.Length > 0)
        {
            if (!sliderOpen)
            {
                animator.SetTrigger("OpenSlider");
                sliderOpen = true;
            }
            RunDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textField.text = "";
        animator.SetTrigger("CloseSlider");
        sliderOpen = false;
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
            animator.SetTrigger("CloseSlider");
            sliderOpen = false;
            currentDialogueIdx = 0;
            textField.text = "";
        }
    }
}
