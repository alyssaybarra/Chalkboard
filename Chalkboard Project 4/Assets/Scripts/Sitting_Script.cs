using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sitting_Script : MonoBehaviour
{
    public GameObject sittingUI;
    bool isActive;
    bool isSitting;
    public GameObject playerModel;
    public GameObject playerObject;
    public GameObject camera;
    public GameObject playerSitting;
    public GameObject bench;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        isSitting = false;
        sittingUI.SetActive(isActive);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSitting) 
        {
            float movement = -1 * timer + 18;
            Vector3 differncePos = bench.transform.position;
            camera.transform.eulerAngles = new Vector3(-15f - movement,90f,0f);
            camera.transform.position = differncePos + (new Vector3(Mathf.Cos(Mathf.PI * 5/6) * movement, 1.5f, 1f));
        }
        if (isSitting && !isActive && timer < Time.deltaTime)
        {
            timer = 0;
            isActive = true;
            sittingUI.SetActive(isActive);
        }
        else if (isSitting && isActive && timer == 0) 
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                isSitting = false;
                playerModel.SetActive(true);
                playerModel.GetComponent<PlayerMovement>().canMove = true;
                camera.GetComponent<CameraController>().isLocked = false;
                playerSitting.SetActive(false);
            }
        }
        else if (isSitting)
        {
            timer -= Time.deltaTime;
        }
        else if (isActive && !isSitting && Input.GetKeyDown(KeyCode.C))
        {
            isSitting = true;
            playerModel.GetComponent<PlayerMovement>().canMove = false;
            camera.GetComponent<CameraController>().isLocked = true;
            playerModel.SetActive(false);
            playerSitting.SetActive(true);
            isActive = false;
            timer = 15f;
        }
        sittingUI.SetActive(isActive);
    }
    private void OnTriggerEnter(Collider other)
    {
        isActive = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("here");
        isActive = false;
        sittingUI.SetActive(isActive);
    }
}
