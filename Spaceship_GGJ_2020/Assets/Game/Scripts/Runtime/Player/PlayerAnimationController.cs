using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private PlayerMovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<PlayerMovementController>();
    }

    private void Update()
    {
        animator.SetFloat("Running", (movementController.Velocity.sqrMagnitude > 0.01f)? 1 : 0);
        animator.SetBool("Ladder", movementController.MovementState == PlayerMovementController.Movement.OnLadder);
    }
}
