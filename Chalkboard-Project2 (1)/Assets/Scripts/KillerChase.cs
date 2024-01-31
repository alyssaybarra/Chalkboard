using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerChase : MonoBehaviour
{
    public Transform player;
    public float speed = 10f;

    void Update()
    {
        transform.LookAt(player);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
