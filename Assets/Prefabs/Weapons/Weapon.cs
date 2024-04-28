using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    // Consider updating EventSystem in Unity //

    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    // [Serialize]
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] float timeBetweenShots = .5f;

    EventSystem eventSystem;

    bool canShoot = true;

    void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        // if (Input.GetButtonDown("Fire1"))
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            // Shoot();
            StartCoroutine(Shoot());
        }

        eventSystem = FindObjectOfType<EventSystem>();
    }

    // void Shoot()
    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        if (Time.timeScale == 0) return;
        if (eventSystem.currentSelectedGameObject != null) return;
        if (eventSystem.IsPointerOverGameObject()) return;

        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            // Debug.Log(hit.transform.name + " was hit.");
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) { return; }
            // Debug.Log(target);
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
