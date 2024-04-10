using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    int curText;
    bool isIn = false;
    [SerializeField]
    List<TextMeshProUGUI> dialougeOptions;
    int selectDialougeOption;
    [SerializeField]
    List<string> branch1;
    [SerializeField]
    List<string> branch2;
    [SerializeField]
    List<string> branch3;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        this.curText = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && Input.GetMouseButtonDown(0) && this.curText < branch1.Count - 1)
        {
            this.curText += 1;
            if (this.curText == 1) 
            {
                foreach (TextMeshProUGUI option in dialougeOptions) 
                {
                    option.gameObject.SetActive(false);
                }
            }
            switch (selectDialougeOption)
            {
                case (0):
                    text.text = branch1[this.curText];
                    break;
                case (1):
                    text.text = branch2[this.curText];
                    break;
                case (2):
                    text.text = branch3[this.curText];
                    break;
            }
        }
        else if (isIn && Input.GetKeyDown(KeyCode.E) && selectDialougeOption < 1) 
        {
            dialougeOptions[selectDialougeOption].color = Color.white;
            selectDialougeOption += 1;
            dialougeOptions[selectDialougeOption].color = Color.red;
        }
        else if (isIn && Input.GetKeyDown(KeyCode.Q) && selectDialougeOption > 0)
        {
            dialougeOptions[selectDialougeOption].color = Color.white;
            selectDialougeOption -= 1;
            dialougeOptions[selectDialougeOption].color = Color.red;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        text.gameObject.SetActive(true);
        isIn = true;
        text.text = branch1[this.curText];
        selectDialougeOption = 0;
        foreach (TextMeshProUGUI option in dialougeOptions)
        {
            option.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
        isIn = true;
        curText = 0;
        foreach (TextMeshProUGUI option in dialougeOptions)
        {
            option.gameObject.SetActive(false);
            option.color = Color.white;
        }
        dialougeOptions[0].color = Color.red;


    }
}
