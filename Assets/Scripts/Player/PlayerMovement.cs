using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Player chars
    [SerializeField] private float p_JumpForce = 10f;
    [SerializeField] private float p_Sensitivity = 0.3f;
    [SerializeField] private float p_XRotation = 0f;

    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    private bool isSprinting;

    // References
    [SerializeField] private Transform p_cameraTransform;
    
    // Player input
    private PlayerInputActions p_Actions;
    private Rigidbody p_Rigidbody;
    
    // Player movements
    private Vector2 p_MoveInput;
    private Vector3 p_LookInput;
    private bool p_JumpInput;

    private void Start()
    {
        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Awake()
    {
        // Initialize player
        p_Actions = new PlayerInputActions();
        p_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Movement
        MovementUpdate();
        // Jump
        if (p_JumpInput) JumpUpdate();
    }

    private void MovementUpdate()
    {
        float speed = isSprinting ? runSpeed : walkSpeed;
        // Previous code was about the world space coordinates
        // Now we use the camera space coordinates
        Vector3 forward = p_cameraTransform.forward;
        Vector3 right = p_cameraTransform.right;
        
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        
        Vector3 dir = forward * p_MoveInput.y + right * p_MoveInput.x;
        
        Vector3 velocity = dir * speed;
        velocity.y = p_Rigidbody.linearVelocity.y;
        
        p_Rigidbody.linearVelocity = velocity;
    }

    private void JumpUpdate()
    {
        p_Rigidbody.AddForce(Vector3.up * p_JumpForce, ForceMode.Impulse);
        p_JumpInput = false;
    }

    private void OnEnable()
    {
        p_Actions.Enable();
        // Movement
        p_Actions.Player.Move.performed += OnMove;
        p_Actions.Player.Move.canceled += OnMove;
        
        // Run
        p_Actions.Player.Sprint.performed += OnSprint;
        p_Actions.Player.Sprint.canceled += OnSprint;
        
        // Jump
        p_Actions.Player.Jump.performed += OnJump;
        
        // Look
        p_Actions.Player.Look.performed += OnLook;
    }

    private void OnDisable()
    {
        // Movement
        p_Actions.Player.Move.performed -= OnMove;
        p_Actions.Player.Move.canceled -= OnMove;
        
        // Sprint
        p_Actions.Player.Sprint.performed -= OnSprint;
        p_Actions.Player.Sprint.canceled -= OnSprint;
        
        
        // Jump
        p_Actions.Player.Jump.performed -= OnJump;
        
        // Look
        p_Actions.Player.Look.performed -= OnLook;
        p_Actions.Disable();
    }

    // Handlers
    private void OnMove(InputAction.CallbackContext ctx)
    {
        p_MoveInput = ctx.ReadValue<Vector2>();
    }
    
    private void OnSprint(InputAction.CallbackContext ctx)
    {
        isSprinting = ctx.ReadValueAsButton();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        p_JumpInput = ctx.ReadValueAsButton();
    }

    private void OnLook(InputAction.CallbackContext ctx)
    {
        p_LookInput = ctx.ReadValue<Vector2>();
        
        float mouseX = p_LookInput.x * p_Sensitivity;
        float mouseY = p_LookInput.y * p_Sensitivity;

        // Vertical
        p_XRotation -= mouseY;
        p_XRotation = Mathf.Clamp(p_XRotation, -80f, 80f);

        p_cameraTransform.localRotation =
            Quaternion.Euler(p_XRotation, 0f, 0f);

        // Horizontal
        transform.Rotate(Vector3.up * mouseX);
    }
}