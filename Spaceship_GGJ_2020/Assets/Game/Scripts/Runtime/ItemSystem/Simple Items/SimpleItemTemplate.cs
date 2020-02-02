using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SimpleItemTemplate : ItemTemplate, IItemID
{
    [SerializeField] private string itemName = "";
    [SerializeField] private Sprite sprite = null;
    [SerializeField] private Color color = Color.white;

    [NaughtyAttributes.Button("Set Default Name")]
    private void OnValidate()
    {
        if(string.IsNullOrEmpty(itemName))
        {
            itemName = name;
        }
    }

    public override IItem GetItem(Action<Vector3> callback)
    {
        return new SimpleItem(itemName, callback, this, color, sprite);
    }


    // ITEM CLASS

    public class SimpleItem : IItem
    {
        // Cache
        private SpriteRenderer spriteRenderer = null;
        // =====

        private Action<Vector3> droppedCallback;
        private Color color;
        private Sprite sprite;

        public string Name { get; }
        public IItemID ID { get; }

        public SimpleItem(string name, Action<Vector3> droppedCallback, IItemID id, Color color, Sprite sprite)
        {
            this.Name = name;
            this.droppedCallback = droppedCallback;
            this.ID = id;
            this.color = color;
            this.sprite = sprite;
        }

        public void Dropped(Vector3 position) => droppedCallback?.Invoke(position);
        public void Use(IShipModule currentModule, Vector3 _) => currentModule?.UseItem(this);

        public void Equipped(GameObject holder)
        {
            Debug.Log("Equipped " + Name);
            if(holder.TryGetComponent(out spriteRenderer))
            {
                spriteRenderer.color = color;
                spriteRenderer.sprite = sprite;
            }
        }

        public void Dequipped()
        {
            Debug.Log("Dequipped " + Name);
            if (spriteRenderer)
            {
                spriteRenderer.color = Color.clear;
                spriteRenderer.sprite = null;
            }
        }
    }
}
