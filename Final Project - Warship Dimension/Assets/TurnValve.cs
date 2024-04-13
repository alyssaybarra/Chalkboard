using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnValve : MonoBehaviour
{
    bool hasBeenTurned = false;
    bool hasPermissionToTurn = false;
    bool inRange = false;
    bool turning = false;
    float turningTime = 1.5f;
    [SerializeField]
    GameObject wheel;
    [SerializeField]
    GameObject fog;
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    TalkingScript talkingScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasBeenTurned && inRange && hasPermissionToTurn) {
            turning = true;
            hasBeenTurned = true;
            talkingScript.setOption(3, true);
        }
        if (turning) {
            if (turningTime == 0)
            {
                turning = false;
                fog.SetActive(false);
            }
            else if (turningTime < Time.deltaTime)
            {
                turningTime = 0;
            }
            else 
            {
                turningTime -= Time.deltaTime;
                Vector3 angles = wheel.transform.rotation.eulerAngles;
                wheel.transform.rotation = Quaternion.Euler(angles.x, angles.y, angles.z + (180 * Time.deltaTime));
            }
        }
        if (hasPermissionToTurn && !hasBeenTurned)
        {
            text.text = "I'll give it a try (Click to turn)";
        }
        else if (!hasPermissionToTurn) {
            text.text = "I should ask the engineer, he's probably nearby. " +
                "\nI'm not going to break a dimension AND get on its people's badsides";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        text.gameObject.SetActive(true);
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
        inRange = false;
    }

    public void enableTurning() 
    {
        this.hasPermissionToTurn = true;
    }
}
