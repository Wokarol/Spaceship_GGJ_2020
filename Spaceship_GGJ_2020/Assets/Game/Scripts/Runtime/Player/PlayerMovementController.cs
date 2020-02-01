using NaughtyAttributes;
using System;
using UnityEngine;

class PlayerMovementController : MonoBehaviour
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

    private int ladderCount = 0;
    private bool IsTouchingLadder => ladderCount > 0;
    private Movement movementState;

    private float lastGravityScale = -1;

    public Func<Vector2> GetMovementInput { get; set; }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        lastGravityScale = body.gravityScale;
    }

    private void Update()
    {
        Vector2 velocity = body.velocity;
        Vector2 movementInput = GetMovementInput();

        switch (movementState)
        {
            case Movement.OnGround:
                velocity.x = movementInput.x * speed;
                if (IsTouchingLadder)
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
                if (IsTouchingLadder && movementInput.y > 0.5f)
                {
                    SwitchMovementState(Movement.OnLadder);
                }
                break;
            case Movement.OnLadder:
                velocity = movementInput * speed;
                if (!IsTouchingLadder)
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

        if (newState == Movement.OnLadder)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ladderTag))
        {
            ladderCount += 1;
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ladderTag))
        {
            ladderCount -= 1;
            return;
        }
    }
}
