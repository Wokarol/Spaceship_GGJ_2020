using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

class PlayerMovementController : MonoBehaviour
{
    [System.Serializable]
    public enum Movement
    {
        Invalid, OnGround, InAir, OnLadder
    }

    [SerializeField] private float speed = 10;
    [SerializeField, Tag] private string ladderTag = "";
    [SerializeField] private float groundCheckDistance = 0.51f;
    [SerializeField] private LayerMask groundMask = 0;
    [SerializeField] private float airSpeedModifier = 0.5f;
    [Space]
    [SerializeField] private string gamepadScheme = null;
    private Rigidbody2D body;

    private int ladderCount = 0;
    private bool IsTouchingLadder => ladderCount > 0;
    [Header("Debug")]
    [SerializeField]
    private Movement movementState = Movement.Invalid;

    private float lastGravityScale = -1;

    private Vector2 movementInput;
    private bool usingGamepad;

    private bool facingRight;
    private Vector2 velocity;

    public Movement MovementState => movementState;
    public Vector2 Velocity => velocity;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        lastGravityScale = body.gravityScale;

        SwitchMovementState(Movement.InAir);
    }

    private void Update()
    {
        velocity = body.velocity;

        switch (movementState)
        {
            case Movement.OnGround:
                float xInput = movementInput.x;
                if (!usingGamepad)
                {
                    if (xInput != 0)
                    {
                        xInput = Mathf.Sign(xInput);
                    }
                }
                velocity.x = xInput * speed;
                velocity.y = 0;
                if (IsTouchingLadder &&
                    (movementInput.y > 0.5f || (movementInput.y < -0.5f && !IsGrounded())))
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
                if (usingGamepad)
                {
                    if (Mathf.Abs(movementInput.y) > 0.5)
                    {
                        movementInput.x *= 0.2f;
                    }
                }

                if (!IsTouchingLadder)
                {
                    SwitchMovementState(Movement.InAir);
                }
                if (IsGrounded())
                {
                    SwitchMovementState(Movement.OnGround);
                }

                break;
        }

        if (velocity.x != 0)
        {
            facingRight = velocity.x > 0;
        }

        Vector3 scale = transform.localScale;
        if (scale.x > 0 != facingRight)
        {
            scale.x *= -1;
        }
        transform.localScale = scale;

        body.velocity = velocity;
    }

    private bool IsGrounded() => Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask).collider;
    private void SnapToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
        if (hit.collider)
            transform.position = hit.point;
    }

    private void SwitchMovementState(Movement newState)
    {
        //Debug.Log($"Changing state from: {movementState} to {newState}");

        if (newState == movementState)
            return;

        if (newState == Movement.OnGround)
        {
            SnapToGround();
        }

        if ((movementState == Movement.InAir || movementState == Movement.Invalid) && (newState == Movement.OnLadder || newState == Movement.OnGround))
        {
            lastGravityScale = body.gravityScale;
            body.gravityScale = 0;
        }

        if (newState == Movement.InAir)
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

    // Input
    public void OnControlsChanged(PlayerInput input)
    {
        usingGamepad = input.currentControlScheme == gamepadScheme;
    }

    public void OnMovement(InputValue v)
    {
        Vector2 input = v.Get<Vector2>();
        if (input.sqrMagnitude < 0.4f * 0.4f)
        {
            movementInput = Vector2.zero;
        }
        else
        {
            movementInput = input;
        }
    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(20, 20, 100, 20), $"State: {movementState}");
    //    GUI.Label(new Rect(20, 35, 100, 20), $"Gravity: {body.gravityScale}");
    //}
}
