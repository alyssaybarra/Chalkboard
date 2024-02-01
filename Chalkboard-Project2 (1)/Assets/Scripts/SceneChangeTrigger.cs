using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // if this breaks, just loadScene(1)
        // im abstracting for no good reason
        //SceneManager.LoadScene(other.gameObject.scene.buildIndex + 1);

        // this is specific for PROJECT 2!!
        if (other.gameObject.scene.buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            ChaseManager.chase = true;
            SceneManager.LoadScene(0);
        }
    }
}
