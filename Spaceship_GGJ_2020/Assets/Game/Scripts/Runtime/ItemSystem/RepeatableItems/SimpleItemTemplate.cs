using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SimpleItemTemplate : ItemTemplate, IItemID
{
    [SerializeField] private string itemName = "";
    [SerializeField] private Color color = Color.white;

    [NaughtyAttributes.Button("Set Default Name")]
    private void OnValidate()
    {
        if(string.IsNullOrEmpty(itemName))
        {
            itemName = name;
        }
    }

    public override IItem GetItem(Action<Vector3> callback) => new SimpleItem(itemName, callback, this, color);

    public class SimpleItem : IItem
    {
        // Cache
        private SpriteRenderer spriteRenderer;
        // =====

        private Action<Vector3> droppedCallback;
        private Color color;

        public string Name { get; }
        public IItemID ID { get; }

        public SimpleItem(string name, Action<Vector3> droppedCallback, IItemID id, Color color)
        {
            this.Name = name;
            this.droppedCallback = droppedCallback;
            this.ID = id;
            this.color = color;
        }

        public void Dropped(Vector3 position) => droppedCallback?.Invoke(position);
        public void Use(IShipModule currentModule, Vector3 _) => currentModule?.UseItem(this);

        public void Equipped(GameObject holder)
        {
            Debug.Log("Equipped " + Name);
            if(holder.TryGetComponent(out SpriteRenderer sprite))
            {
                sprite.color = color;
            }
        }

        public void Dequipped()
        {
            Debug.Log("Dequipped " + Name);
            if (spriteRenderer)
            {
                spriteRenderer.color = Color.clear;
            }
        }
    }
}
