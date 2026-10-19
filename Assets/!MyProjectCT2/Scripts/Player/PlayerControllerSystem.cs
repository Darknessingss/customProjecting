using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerSystem : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 7f;

    [SerializeField] private Rigidbody rb;
    private Vector2 moveInput;
    private bool jumpPressed;
    private bool isGrounded;
    private int groundContacts;

    private PlayerControls playerControls;

    private void Awake()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.PlayerMovement.Enable();
        playerControls.PlayerMovement.Move.performed += OnMove;
        playerControls.PlayerMovement.Move.canceled += OnMove;
        playerControls.PlayerMovement.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        playerControls.PlayerMovement.Move.performed -= OnMove;
        playerControls.PlayerMovement.Move.canceled -= OnMove;
        playerControls.PlayerMovement.Jump.performed -= OnJump;
        playerControls.PlayerMovement.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        jumpPressed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) groundContacts++;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) groundContacts--;
    }

    private void FixedUpdate()
    {
        isGrounded = groundContacts > 0;

        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        move = Vector3.ClampMagnitude(move, 1f);

        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y,move.z * moveSpeed);

        if (jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
        jumpPressed = false;
    }
}