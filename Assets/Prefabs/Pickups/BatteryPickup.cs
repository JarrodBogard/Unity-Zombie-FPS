using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 50f;
    [SerializeField] float addIntensity = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player picked up battery");
            other.GetComponentInChildren<FlashlightSystem>().AddLightIntensity(addIntensity);
            other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(restoreAngle);
            Destroy(gameObject);
        }
    }
}
