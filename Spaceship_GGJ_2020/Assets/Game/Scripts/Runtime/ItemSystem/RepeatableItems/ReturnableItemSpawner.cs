using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnableItemSpawner : MonoBehaviour, IItemPickup
{
    public string Name => name;


    [SerializeField] private ItemTemplate itemTemplate = null;
    [SerializeField] private Animator animator;

    private bool itemInSlot = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("Filled", itemInSlot);
    }

    public IItem GetItem()
    {
        if(itemInSlot)
        {
            itemInSlot = false;
            return itemTemplate.GetItem(ItemDroppedCallback);
        }
        return null;
    }

    public void ItemDroppedCallback(Vector3 _)
    {
        itemInSlot = true;
    }
}
