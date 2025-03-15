using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour {

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool canJump;

    [Header("Controller Inputs")]
    PlayerInput playerInput;

    public InputActionReference LJoyInput;
    public InputActionReference jump;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    public Transform orientation;

    Vector2 move;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        move = LJoyInput.action.ReadValue<Vector2>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update() {

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);

        //MoveInput();
        SpeedControl();

        //handle drag
        if (grounded) {
            LJoyInput.action.started += MoveInput;
            rb.drag = groundDrag;
        }
        else {
            LJoyInput.action.started -= MoveInput;
            rb.drag = 0;
        }
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void OnEnable() {
        
        jump.action.started += Jump;
    }

    private void OnDisable() {
        
        jump.action.started -= Jump;
    }

    private void MoveInput(InputAction.CallbackContext moveContext) {
        if(canJump && grounded) {
            canJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer() {
        //calculate movement direction
        moveDirection = orientation.forward * move.y + orientation.right * move.x;

        //on ground
        if (grounded && move.x == 0 && move.y == 0) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }

    private void SpeedControl() {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
        rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
    }

    private void Jump(InputAction.CallbackContext jumpContext) {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() {
        canJump = true;
    }
}
