using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
// using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    // [SerializeField] Camera fpsCamera;
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 1f;

    // FirstPersonController fpsController;
    // RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;

    // void Start()
    // {
    //     fpsController = GetComponentInParent<FirstPersonController>();
    // fpsController = GetComponent<FirstPersonController>();
    // fpsController = GetComponent<RigidbodyFirstPersonController>();
    // }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (!zoomedInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    void OnDisable()
    {
        ZoomOut();
    }

    void ZoomIn()
    {
        zoomedInToggle = true;
        fpsController.RotationSpeed = zoomedInSensitivity;
        fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
        // fpsCamera.fieldOfView = zoomedInFOV;
        // fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        // fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    void ZoomOut()
    {
        zoomedInToggle = false;
        fpsController.RotationSpeed = zoomedOutSensitivity;
        fpsCamera.m_Lens.FieldOfView = zoomedOutFOV;
        // fpsCamera.fieldOfView = zoomedOutFOV;
        // fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        // fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }

}
