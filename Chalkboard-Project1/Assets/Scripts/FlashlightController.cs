using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public float flashlightLifetime;

    private Light flashlight;
    private float maxFlashlightBrightness;
    private float currentFlashlightLife;

    void Start()
    {
        flashlight = gameObject.GetComponent<Light>();
        maxFlashlightBrightness = flashlight.intensity;
        currentFlashlightLife = flashlightLifetime;
    }

    void Update()
    {
        if (currentFlashlightLife > 0)
        {
            currentFlashlightLife -= Time.deltaTime;

            float flashlightPercent = currentFlashlightLife / flashlightLifetime;

            flashlight.intensity = 0.5f + Mathf.Min(maxFlashlightBrightness, (maxFlashlightBrightness * flashlightPercent)); // minimum intensity: 0.5f
            flashlight.spotAngle = 50 + (10 * flashlightPercent); //ranges from 50 - 60
        }
        else
        {
            flashlight.intensity = 0.0f;
            currentFlashlightLife = 0;
        }
    }

    public void PickupBattery()
    {
        currentFlashlightLife = flashlightLifetime;
    }
}
