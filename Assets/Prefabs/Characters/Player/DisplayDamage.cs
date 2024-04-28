using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageTakenCanvas;
    [SerializeField] float damageTakenTime = .3f;

    void Start()
    {
        damageTakenCanvas.enabled = false;
    }

    public void ShowDamageTaken()
    {
        StartCoroutine(ShowDamageSplatter());
    }

    IEnumerator ShowDamageSplatter()
    {
        damageTakenCanvas.enabled = true;
        yield return new WaitForSeconds(damageTakenTime);
        damageTakenCanvas.enabled = false;
    }
}
