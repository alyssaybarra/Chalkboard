using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseManager : MonoBehaviour
{
    public GameObject killer;
    public GameObject player;
    public Transform killerStartLocation;
    public Transform playerStartLocation;
    public static bool chase = false;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (chase)
        {
            GameObject killerGO = Instantiate(killer);
            killerGO.transform.position = killerStartLocation.position;
            killerGO.transform.rotation = killerStartLocation.rotation;
            player.transform.position = playerStartLocation.position;
            player.transform.rotation = playerStartLocation.rotation;
            killer.GetComponent<KillerChase>().player = player.transform;
            playerCamera.fieldOfView = 85;
        }
    }

    void Update()
    {
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
