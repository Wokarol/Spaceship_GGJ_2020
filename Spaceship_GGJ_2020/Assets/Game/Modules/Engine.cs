using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : ShipModule, IDamageModifier
{
    [Space, Header("==========")]
    [SerializeField, Range(0, .5f)] private float evadeChance = 0.125f;

    private void OnEnable()
    {
        EnemyShip.DamageModifiers.Add(this);
    }

    public void ModifyDamage(ref float damage, ref float evade)
    {
        if (IsWorking)
        {
            evade += evadeChance;
        }
    }
}
