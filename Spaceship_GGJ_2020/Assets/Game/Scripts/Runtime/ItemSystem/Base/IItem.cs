using UnityEngine;

public interface IItem
{
    string Name { get; }
    IItemID ID { get; }
    void Use(IShipModule currentModule, Vector3 position);
    void Dropped(Vector3 position);
    void Equipped(GameObject holder);
    void Dequipped();
}