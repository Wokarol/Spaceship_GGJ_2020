using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : GameObjectItem
{
    [SerializeField] private Transform shotPoint;
    [Space]
    [SerializeField] private Transform shotEffect;
    [SerializeField] private Transform hitEffect;
    [SerializeField] private float hitDelay = 0.04f;
    [Space]
    [SerializeField] private LayerMask hitMask;
    [Space]
    [SerializeField] private Transform trailPrefab = null;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Use(IShipModule _)
    {
        Shoot();
    }

    [Button("Shoot [RUNTIME]")]
    private void Shoot()
    {
        if (!Application.isPlaying)
            return;

        var shotEffectGO = Instantiate(shotEffect, shotPoint);
        shotEffectGO.parent = null;

        animator.SetTrigger("Shot");

        var hit = Physics2D.Raycast(shotPoint.transform.position, shotPoint.TransformDirection(Vector3.right), 500, hitMask);
        Wokarol.Scheduler.DelayCall(() => SpawnHit(hit), hitDelay);

        DoTrail(hit);

        if (hit.collider == null)
            return;

        if(hit.collider.TryGetComponent(out EnemyAI enemyAI))
        {
            enemyAI.Die();
        }
    }

    private void DoTrail(RaycastHit2D hit)
    {
        var trail = Instantiate(trailPrefab, shotPoint.position, Quaternion.identity);
        trail.localScale = new Vector3(shotPoint.TransformDirection(Vector3.right).x * hit.distance, 1, 1);
    }

    private void SpawnHit(RaycastHit2D hit)
    {
        Instantiate(hitEffect, hit.point, Quaternion.LookRotation(Vector3.forward, hit.normal) * Quaternion.Euler(0, 0, 90));
    }
}
