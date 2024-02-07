using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastCannonBehavior : MonoBehaviour
{
    public GameObject breakable;
    public ParticleSystem breakParticles;

    private bool shot;

    void OnTriggerStay(Collider col)
    {
        if (Input.GetMouseButtonDown(0) && col.tag == "CannonDetector")
        {
            Vector3 breakLocation = breakable.transform.position;
            
            ParticleSystem p = Instantiate(breakParticles);
            p.transform.position = breakLocation;
            Invoke(nameof(DestroyBreakable), 1);
        }
    }

    private void DestroyBreakable()
    {
        breakable.SetActive(false);
    }
}
