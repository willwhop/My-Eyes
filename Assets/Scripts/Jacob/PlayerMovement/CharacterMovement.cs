using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float moveSpeed, groundDrag, jumpForce, jumpCooldown, airMultiplier;
    [SerializeField] private Transform orientation;

    [Header("Controller Inputs")]
    PlayerInput playerInput;

    [SerializeField] private InputActionReference LJoyInput;
    [SerializeField] private InputActionReference jump;

    [Header("Ground Check")]
    [SerializeField] private LayerMask ground;

    float playerHeight = 2;
    bool grounded;
    bool canJump;

    Vector2 move;
    Vector3 moveDirection;

    Rigidbody rb;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update() {
        move = LJoyInput.action.ReadValue<Vector2>();

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.32f, ground);

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

    private void MoveInput(InputAction.CallbackContext context) {
        if (canJump && grounded) {
            canJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer() {
        //calculate movement direction
        moveDirection = orientation.forward * move.y + orientation.right * move.x;

        //on ground
        if (grounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //in air
        else if (!grounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl() {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVelocity.magnitude > moveSpeed) {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump(InputAction.CallbackContext jumpContext) {
        if (grounded) {
            //reset y velocity
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void ResetJump() {
        canJump = true;
    }
}
