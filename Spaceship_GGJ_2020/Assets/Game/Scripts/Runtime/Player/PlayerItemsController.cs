using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsController : MonoBehaviour
{
    private PlayerModuleInteractionController moduleController;

    private IItem currentItem;
    private IItem secondaryItem;

    private IItemPickup currentPickup;

    private void Awake()
    {
        moduleController = GetComponent<PlayerModuleInteractionController>();
    }

    public void OnPickup()
    {
        if (currentPickup != null)
        {
            if(secondaryItem == null)
            {
                OnSwap();
            }
            if(currentItem != null)
            {
                currentItem.Dropped(transform.position);
            }
            currentItem = currentPickup.GetItem();
        }
        else
        {
            Debug.Log("No pickups to pick");
        }
    }

    public void OnSwap()
    {
        var temp = currentItem;
        currentItem = secondaryItem;
        secondaryItem = temp;
    }

    public void OnUseItem()
    {
        if(currentItem != null)
        {
            currentItem.Use(moduleController.CurrentModule);
        }
        else
        {
            Debug.Log("No Item to use");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IItemPickup pickup))
        {
            if (currentPickup != null)
                Debug.LogWarning("Overridding current pickup!");
            currentPickup = pickup;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IItemPickup pickup))
        {
            if (pickup != currentPickup)
            {
                Debug.LogWarning("Trying to remove module that is not current!");
                return;
            }

            currentPickup = null;
        }
    }

    private void OnGUI()
    {
        float offset = 40;
        GUI.Label(new Rect(20, 20 + offset, 400, 20), $"Item [1]: {currentItem?.Name}");
        GUI.Label(new Rect(20, 35 + offset, 400, 20), $"Item [2]: {secondaryItem?.Name}");
        GUI.Label(new Rect(20, 50 + offset, 400, 20), $"Pickup: {currentPickup?.Name}");
    }
}
