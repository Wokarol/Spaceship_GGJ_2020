using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum Movement
    {
        OnGround, InAir, OnLadder
    }

    [SerializeField] private float speed = 10;
    [SerializeField, Tag] private string ladderTag = "";
    [SerializeField] private float groundCheckDistance = 0.51f;
    [SerializeField] private LayerMask groundMask = 0;
    [SerializeField] private float airSpeedModifier = 0.5f;

    private Rigidbody2D body;
    private GameplayInput input;

    private bool isTouchingLadder;
    private Movement movementState;

    private float lastGravityScale = -1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        input = new GameplayInput();
        input.General.Interact.performed += OnInteract;
        input.Enable();

        lastGravityScale = body.gravityScale;
    }

    private void Update()
    {
        Vector2 velocity = body.velocity;
        Vector2 movementInput = input.General.Movement.ReadValue<Vector2>();

        switch (movementState)
        {
            case Movement.OnGround:
                velocity.x = movementInput.x * speed;
                if (isTouchingLadder)
                {
                    SwitchMovementState(Movement.OnLadder);
                }
                break;
            case Movement.InAir:
                velocity.x = movementInput.x * speed * airSpeedModifier;
                if (IsGrounded())
                {
                    SwitchMovementState(Movement.OnGround);
                }
                if (isTouchingLadder && movementInput.y > 0.5f)
                {
                    SwitchMovementState(Movement.OnLadder);
                }
                break;
            case Movement.OnLadder:
                velocity = movementInput * speed;
                if (!isTouchingLadder)
                {
                    SwitchMovementState(Movement.InAir);
                }

                break;
        }

        body.velocity = velocity;
    }

    private bool IsGrounded() => Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask).collider;

    private void SwitchMovementState(Movement newState)
    {
        if (newState == movementState)
            return;

        if(newState == Movement.OnLadder)
        {
            lastGravityScale = body.gravityScale;
            body.gravityScale = 0;
        }

        if (newState != Movement.OnLadder)
        {
            body.gravityScale = lastGravityScale;
        }

        movementState = newState;
    }

    private void OnInteract(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Debug.Log("Interacted");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ladderTag))
        {
            isTouchingLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ladderTag))
        {
            isTouchingLadder = false;
        }
    }
}
