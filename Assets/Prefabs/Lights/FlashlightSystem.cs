using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    // [SerializeField] float angleDecay = 1f;
    [SerializeField] float angleDecay = .2f;
    [SerializeField] float minimumAngle = 30f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    public void AddLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    void DecreaseLightIntensity()
    {
        if (myLight.intensity <= 0) { return; }
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
}
