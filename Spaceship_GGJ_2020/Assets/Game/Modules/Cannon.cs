using System;
using UnityEngine;

public class Cannon : ShipModule
{
    [Space]
    [SerializeField] private float timeBetweenShots = 5;
    [SerializeField] private float damage = 0.05f;
    [Space]
    [SerializeField] private GameDirector director = null;
    float timer;

    protected override void Update()
    {
        base.Update();

        if (IsWorking)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenShots)
            {
                timer -= timeBetweenShots;
                Shot();
            }
        }
        else
        {
            timer = 0;
        }
    }

    private void Shot()
    {
        director.Enemy.Damage(damage);
    }
}
