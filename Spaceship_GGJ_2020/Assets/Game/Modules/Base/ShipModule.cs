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

    [Header("Debug")]
    [SerializeField, Range(0, 1)] private float stability = 1;
    [SerializeField] private Effect currentEffect = Effect.None;

    public string Name => name;
    public bool Broken { get; private set; }
    public bool IsWorking => !Broken && currentEffect != Effect.ElectricShok;

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
}
