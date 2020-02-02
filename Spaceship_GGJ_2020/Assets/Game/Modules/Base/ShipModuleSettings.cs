using UnityEngine;

[CreateAssetMenu]
public class ShipModuleSettings : ScriptableObject
{
    public float StabilityRegenerationSpeed;
    public float FireStabilitySpeed;
    public ItemTemplate ExtinguisherID;
    public ItemTemplate ElectricResetterID;
    public ItemTemplate WrenchID;
}
