using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLOT : ShipModule
{
    [SerializeField] private float casualShootingInterval;
    [SerializeField] private float timeToAttack;
    [SerializeField] private float firstTimeToAttack;
    [Space]
    [SerializeField] private Animator animator;

    float timer = 0;
    float attackCountdown = 0;

    protected override void Update()
    {
        base.Update();
        if (IsWorking)
        {
            timer += Time.deltaTime;
            if (timer > casualShootingInterval)
            {
                timer -= casualShootingInterval;
                animator.SetTrigger("Shot");
            } 
        }
    }
}
