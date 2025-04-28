using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour {

    [SerializeField] private float moveSpeed, groundDrag, jumpForce, jumpCooldown, airMultiplier, scaryAbilityCooldown, lerpSpeed, alphaSetting;
    [SerializeField] private Transform orientation, flowerAnchor;

    PlayerInput playerInput;

    [SerializeField] private InputActionReference LJoyInput, jump, specialAbility;
    [SerializeField] private GameObject eyesSocket, flowerObj, flower, growTrigger, playerSprite;

    [Header("Ground Check")]
    [SerializeField] private LayerMask ground;

    public bool grounded;

    private Color scaryColour;

    private float playerHeight = 2, lerpChoice;
    private bool canJump;

    Vector2 move;
    Vector3 moveDirection;

    [SerializeField] private AudioClip jumpClip;
    AudioSource audioSource;

    Rigidbody rb;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        audioSource = GetComponent<AudioSource>();
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
        else if (!grounded) {
            LJoyInput.action.started -= MoveInput;
            rb.drag = 0;
        }
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void OnEnable() {
        jump.action.started += Jump;
        specialAbility.action.started += SpecialAbility;
    }

    private void OnDisable() {
        jump.action.started -= Jump;
        specialAbility.action.started -= SpecialAbility;
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
            growTrigger.GetComponent<CheckIfCanGrow>().ShowGrowIcon();
        }

        //in air
        else if (!grounded) {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            growTrigger.GetComponent<CheckIfCanGrow>().HideGrowIcon();
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
            audioSource.PlayOneShot(jumpClip);
        }
    }

    private void ResetJump() {
        canJump = true;
    }

    private void SpecialAbility(InputAction.CallbackContext specialContext) {
        if (eyesSocket.GetComponent<EyeScript>().boolScary == true) {
            StartCoroutine(ScarySpriteChange());
            
            if (gameObject.GetComponent<InvisibleAbility>().CanTurnInvis == true) {                
                gameObject.GetComponent<InvisibleAbility>().isInVisible = true;
                gameObject.GetComponent<InvisibleAbility>().CanTurnInvis = false;
            }
        }
        if (eyesSocket.GetComponent<EyeScript>().boolCute == true && grounded && growTrigger.GetComponent<CheckIfCanGrow>().canGrow == true) {
            if (flower != null) {
                flower.GetComponent<GrowFlower>().StartCoroutine("Shrink");
                flower = null;
            }
            flower = Instantiate(flowerObj);
            flower.transform.position = flowerAnchor.position;
        }
    }

    private IEnumerator ScarySpriteChange() {
        scaryColour = playerSprite.GetComponent<SpriteRenderer>().color;
        scaryColour.a = 25f;
        yield return new WaitForSeconds(3);
        scaryColour.a = 255;
    }
}
