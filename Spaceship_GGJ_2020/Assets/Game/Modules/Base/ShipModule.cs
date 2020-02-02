using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipModule : MonoBehaviour, IShipModule
{
    public enum Effect
    {
        None,
        Fire,
        ElectricShok
    }

    [SerializeField] private ShipModuleSettings config = null;
    [Space]
    [SerializeField] private GameObject fireEffect = null;

    [SerializeField] private GameObject sparkEffect = null;
    [SerializeField] private DestructionController destruction = null;
    [SerializeField] protected GameDirector director;

    [Header("Debug")]
    [SerializeField, Range(0, 1)] private float stability = 1;
    [SerializeField] private Effect currentEffect = Effect.None;

    public string Name => name;
    public bool Broken { get; private set; }
    public bool IsWorking => !Broken && currentEffect != Effect.ElectricShok;
    public Effect CurrentEffect => currentEffect;

    private void Awake()
    {
        stability = 1;
        currentEffect = Effect.None;
    }

    protected virtual void Update()
    {
        switch (currentEffect)
        {
            case Effect.None:
                stability = Mathf.MoveTowards(stability, 1, config.StabilityRegenerationSpeed * Time.deltaTime);
                break;
            case Effect.Fire:
                stability = Mathf.MoveTowards(stability, 0, config.FireStabilitySpeed * Time.deltaTime);
                break;
        }

        if(IsWorking && stability == 0)
        {
            Broken = true;
        }

        fireEffect.SetActive(currentEffect == Effect.Fire);
        sparkEffect.SetActive(currentEffect == Effect.ElectricShok);
        destruction.IsBroken = Broken;
    }

    public void UseItem(IItem item)
    {
        switch (currentEffect)
        {
            case Effect.Fire when item.ID == config.ExtinguisherID:
                currentEffect = Effect.None;
                return;
            case Effect.ElectricShok when item.ID == config.ElectricResetterID:
                currentEffect = Effect.None;
                return;
        }
        if(Broken && item.ID == config.WrenchID)
        {
            Broken = false;
            stability = 1;
        }
        Interact();
    }

    public virtual void Interact()
    {

    }

    public void Attack(float damage)
    {
        GetRandomEffect();
        director.Player.Damage(damage);
    }

    public void GetRandomEffect()
    {
        int sum = config.BreakHitChance + config.EMPChance + config.FireChance;
        int v = UnityEngine.Random.Range(1, sum + 1);

        if(v <= config.BreakHitChance)
        {
            Broken = true;
            return;
        }

        if (v <= config.BreakHitChance + config.EMPChance)
        {
            currentEffect = Effect.ElectricShok;
            return;
        }

        if (v <= config.BreakHitChance + config.EMPChance + config.FireChance)
        {
            currentEffect = Effect.Fire;
            return;
        }
    }

    public void Damage(float damage)
    {
        stability = Mathf.MoveTowards(stability, 0, damage);
    }
}
