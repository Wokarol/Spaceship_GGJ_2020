using UnityEngine;

[CreateAssetMenu]
public class ShipModuleSettings : ScriptableObject
{
    public float StabilityRegenerationSpeed;
    public float FireStabilitySpeed;
    public ItemTemplate ExtinguisherID;
    public ItemTemplate ElectricResetterID;
    public ItemTemplate WrenchID;

    [Header("Chances")]
    [Range(1, 10)] public int FireChance = 3;
    [Range(1, 10)] public int EMPChance = 3;
    [Range(1, 10)] public int BreakHitChance = 1;
}
