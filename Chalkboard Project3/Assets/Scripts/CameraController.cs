using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static float pitch;
    public static float yaw;
    public Transform camTrans;
    public Transform playerTrans;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yaw = camTrans.rotation.eulerAngles.y;
    }

    void Update()
    {
        //sets the camera's position to follow the player
        camTrans.position = playerTrans.position;

        //rotates the camera and player according to mouse input
        pitch -= Input.GetAxis("Mouse Y");
        yaw += Input.GetAxis("Mouse X");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        while (yaw < 0f) { yaw += 360f; }
        while (yaw >= 360f) { yaw -= 360f; }

        camTrans.eulerAngles = new Vector3(pitch, yaw, 0);
        playerTrans.eulerAngles = new Vector3(0, yaw, 0);
    }
}
