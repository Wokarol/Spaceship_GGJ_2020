using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PrefabItemTemplate : ItemTemplate
{
    [SerializeField] private string itemName = "";
    [SerializeField] private GameObjectItem prefab = null;

    [NaughtyAttributes.Button("Set Default Name")]
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(itemName))
        {
            itemName = name;
        }
    }

    public override IItem GetItem(Action<Vector3> droppedCallback)
    {
        return new PrefabItem(itemName, droppedCallback, this, prefab);
    }


    // ITEM CLASS

    public class PrefabItem : IItem
    {
        // Cache
        private GameObjectItem spawnedPrefab;
        // =====

        private Action<Vector3> droppedCallback;
        private GameObjectItem prefab;

        public string Name { get; }
        public IItemID ID { get; }

        public PrefabItem(string name, Action<Vector3> droppedCallback, IItemID id, GameObjectItem prefab)
        {
            Name = name;
            ID = id;
            this.droppedCallback = droppedCallback;
            this.prefab = prefab;
        }

        public void Dropped(Vector3 position) => droppedCallback?.Invoke(position);
        public void Use(IShipModule currentModule, Vector3 _)
        {
            spawnedPrefab.Use(currentModule);
        }

        public void Equipped(GameObject holder)
        {
            spawnedPrefab = Instantiate(prefab, holder.transform);
        }

        public void Dequipped()
        {
            Destroy(spawnedPrefab.gameObject);
        }
    }
}
