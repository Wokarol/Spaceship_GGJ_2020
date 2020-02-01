using UnityEngine;

public interface IItem
{
    string Name { get; }
    void Use(IShipModule currentModule);
    void Dropped(Vector3 position);
}