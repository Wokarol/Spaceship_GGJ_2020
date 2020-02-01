using UnityEngine;

public interface IItem
{
    string Name { get; }
    IItemID ID { get; }
    void Use(IShipModule currentModule);
    void Dropped(Vector3 position);
}