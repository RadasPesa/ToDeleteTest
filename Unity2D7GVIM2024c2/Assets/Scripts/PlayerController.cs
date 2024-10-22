using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerInput playerInput;
    private InputAction movementAction;
    private Rigidbody2D rb;
    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private Animator animator;

    private Vector2 moveDirection;

    void Awake()
    {
        inputManager = InputManager.instance;
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        movementAction = playerInput.actions["Movement"];
        movementAction.performed += Move;
    }

    void Update()
    {
        moveDirection = movementAction.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    // 50 times per second (every 0.02 seconds)
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * (playerSpeed * Time.fixedDeltaTime));
    }
    
    public void Move(InputAction.CallbackContext ctx)
    {
        
    }
}
