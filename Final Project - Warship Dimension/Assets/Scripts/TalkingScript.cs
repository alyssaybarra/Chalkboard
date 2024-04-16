using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    List<string> branch4;
    [SerializeField]
    List<bool> isAccessable;
    [SerializeField]
    TurnValve turnValve;
    // Start is called before the first frame update
    void Start()
    {
        this.curText = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && Input.GetMouseButtonDown(0) && this.curText < this.getBranch(selectDialougeOption).Count - 1)
        {
            this.curText += 1;
            if (this.curText == 1) 
            {
                foreach (TextMeshProUGUI option in dialougeOptions) 
                {
                    option.gameObject.SetActive(false);
                }
            }
            text.text = this.getBranch(selectDialougeOption)[this.curText];
            if (this.curText > 3 && this.selectDialougeOption == 2) 
            {
                turnValve.enableTurning();
            }
        }
        else if (isIn && Input.GetKeyDown(KeyCode.E) 
            && selectDialougeOption < this.isAccessable.Count - 1
            && this.isAccessable[selectDialougeOption + 1]) 
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
    private List<string> getBranch(int index)
    {
        switch (index)
        {
            case (0):
                return branch1;
            case (1):
                return branch2;
            case (2):
                return branch3;
            case (3):
                return branch4;
        }
        throw new System.Exception("invalidIndex");
    }

    private void OnTriggerEnter(Collider other)
    {
        text.gameObject.SetActive(true);
        isIn = true;
        text.text = branch1[this.curText];
        selectDialougeOption = 0;
        for (int index = 0; index < dialougeOptions.Count; index += 1)
        {
            TextMeshProUGUI option = dialougeOptions[index];
            option.gameObject.SetActive(this.isAccessable[index]);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
        isIn = false;
        curText = 0;
        foreach (TextMeshProUGUI option in dialougeOptions)
        {
            option.gameObject.SetActive(false);
            option.color = Color.white;
        }
        dialougeOptions[0].color = Color.red;


    }

    public void setOption(int index, bool value) 
    {
        this.isAccessable[index] = value;
    }
}
