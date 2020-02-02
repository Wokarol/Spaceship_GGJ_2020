using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : ShipModule, IDamageModifier
{
    [Space, Header("==========")]
    [SerializeField, Range(0.1f, 1f)] private float multiplier = 0.25f;

    private void OnEnable()
    {
        EnemyShip.DamageModifiers.Add(this);
    }

    public void ModifyDamage(ref float damage, ref float evade)
    {
        if (IsWorking)
        {
            damage *= multiplier;
        }
    }
}
