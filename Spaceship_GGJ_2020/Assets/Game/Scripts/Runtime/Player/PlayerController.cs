using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerModuleInteractionController))]
[RequireComponent(typeof(PlayerItemsController))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovementController movementController;
    private PlayerModuleInteractionController playerModuleInteractionController;
    private PlayerItemsController playerItemsController;

    private GameplayInput input;

    private void Awake()
    {
        movementController = GetComponent<PlayerMovementController>();
        playerModuleInteractionController = GetComponent<PlayerModuleInteractionController>();
        playerItemsController = GetComponent<PlayerItemsController>();

        playerItemsController.ModuleController = playerModuleInteractionController;

        input = new GameplayInput();

        input.General.UseItem.performed += (c) => playerItemsController.UseItem();
        input.General.Pickup.performed += (c) => playerItemsController.PickupItem(); ;
        input.General.Swap.performed += (c) => playerItemsController.SwapItems(); ;

        movementController.GetMovementInput = () => input.General.Movement.ReadValue<Vector2>();

        input.Enable();
    }
}
