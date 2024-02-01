using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerChase : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        transform.LookAt(player);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
