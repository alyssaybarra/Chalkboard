using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;
//using System.Diagnostics;

public class KillerChase : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public static bool isGameOver = false;
    public Text gameText;

    private Camera playerCamera; // Reference to the player's camera

    void Start()
    {
        isGameOver = false;
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (isGameOver)
        {
            LevelLost();
            return;
        }

        if (player != null)
        {
            transform.LookAt(player);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            Debug.Log("Collision with player detected!");
            Destroy(gameObject);
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelLost()
    {
        gameText.text = "GAME OVER! YOU WERE MURDERED!!";
        gameText.gameObject.SetActive(true);

        Invoke("LoadLevel", 2);
    }
}