using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Diagnostics;

public class ChaseManager : MonoBehaviour
{
    public GameObject killer;
    public GameObject player;

    public Transform killerStartLocation;
    public Transform playerStartLocation;

    public static bool chase = false;
    public Camera playerCamera;

    public Text gameText;

    public static bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {

        isGameOver = false;


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
        if (isGameOver)
        {
            LevelLost();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGameOver = true;
            Debug.Log("Collision with player detected!");
            gameText.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelLost()
    {
        gameText.text = "GAME OVER! YOU WERE MURDERED!!";
        gameText.gameObject.SetActive(true);

        Invoke("LoadLevel", 2);
    }

}
