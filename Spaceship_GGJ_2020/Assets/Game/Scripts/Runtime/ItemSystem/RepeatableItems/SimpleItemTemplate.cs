using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SimpleItemTemplate : ScriptableObject, IItemID
{
    [SerializeField] private string itemName = "";

    [NaughtyAttributes.Button("Set Default Name")]
    private void OnValidate()
    {
        if(string.IsNullOrEmpty(itemName))
        {
            itemName = name;
        }
    }

    public class SimpleItem : IItem
    {
        private Action<Vector3> droppedCallback;

        public string Name { get; }
        public IItemID ID { get; }

        public SimpleItem(string name, Action<Vector3> droppedCallbakc, IItemID id)
        {
            this.Name = name;
            this.droppedCallback = droppedCallbakc;
            this.ID = id;
        }

        public void Dropped(Vector3 position) => droppedCallback?.Invoke(position);
        public void Use(IShipModule currentModule) => currentModule?.UseItem(this);
    }

}
