using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsController : MonoBehaviour
{
    public PlayerModuleInteractionController ModuleController { get; set; }

    public void OnPickup()
    {
        Debug.Log("Pickup!");
    }

    public void OnSwap()
    {
        Debug.Log("Swap!");
    }

    public void OnUseItem()
    {
        Debug.Log("Use!");
    }
}
