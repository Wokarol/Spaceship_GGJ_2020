using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPickup : MonoBehaviour, IItemPickup
{
    public string Name => name;

    public IItem GetItem()
    {
        Destroy(gameObject);
        return new DummyItem($"{name}");
    }

    public class DummyItem : IItem
    {
        public string Name { get; }

        public IItemID ID => null;

        public DummyItem(string name) => Name = name;


        public void Use(IShipModule currentModule, Vector3 _)
        {
            if(currentModule != null)
            {
                Debug.Log($"Using {Name} => [{currentModule.Name}]");
            }
            else
            {
                Debug.Log($"Using {Name} => [null]");
            }
        }

        public void Dropped(Vector3 position)
        {
            Debug.Log($"Dropped {Name}");
        }

        public void Equipped(GameObject holder)
        {

        }

        public void Dequipped()
        {
            
        }
    }
}
