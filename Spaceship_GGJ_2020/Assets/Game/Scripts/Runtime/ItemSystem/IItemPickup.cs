public interface IItemPickup
{
    string Name { get; }
    IItem GetItem();
}