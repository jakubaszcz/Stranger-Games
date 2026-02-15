using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Player chars
    [SerializeField] private float p_Speed = 10f;
    [SerializeField] private float p_JumpForce = 10f;

    // Player input
    private PlayerInputActions p_Actions;
    private Rigidbody p_Rigidbody;
    
    // Player movements
    private Vector2 p_MoveInput;
    private bool p_JumpInput;

    private void Awake()
    {
        p_Actions = new PlayerInputActions();
        p_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(p_MoveInput.x, 0f, p_MoveInput.y);
        
        Vector3 velocity = dir * p_Speed;
        velocity.y = p_Rigidbody.linearVelocity.y;
        
        p_Rigidbody.linearVelocity = velocity;

        if (p_JumpInput)
        {
            p_Rigidbody.AddForce(Vector3.up * p_JumpForce, ForceMode.Impulse);
            p_JumpInput = false;
        }
    }

    private void OnEnable()
    {
        p_Actions.Enable();
        p_Actions.Player.Move.performed += OnMove;
        p_Actions.Player.Move.canceled += OnMove;
        p_Actions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        p_Actions.Player.Move.performed -= OnMove;
        p_Actions.Player.Move.canceled -= OnMove;
        p_Actions.Player.Jump.performed -= OnJump;
        p_Actions.Disable();
    }

    // Handlers
    private void OnMove(InputAction.CallbackContext ctx)
    {
        p_MoveInput = ctx.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        p_JumpInput = ctx.ReadValueAsButton();
    }
}