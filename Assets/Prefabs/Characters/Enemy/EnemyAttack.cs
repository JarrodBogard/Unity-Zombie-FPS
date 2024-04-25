using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // [SerializeField] Transform target;
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.TakeDamage(damage);
        // target.GetComponent<PlayerHealth>().TakeDamage(damage);
        // Debug.Log("Target has been hit");
    }

    // ONLY USED FOR 'BroadcastMessage' EXAMPLE //
}
