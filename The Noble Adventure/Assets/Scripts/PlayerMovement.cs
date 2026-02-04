using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement:MonoBehaviour
{
    // Varaibles Used
    [SerializeField] protected float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isMoving = false;

    /// <summary>
    /// Sets up our game variables 
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    private void Update()
    {
        // If we're moving and not at the target, move towards it
        if (isMoving)
        {
            // Calculate direction and distance
            Vector2 direction = targetPosition - (Vector2)transform.position;
            float distance = direction.magnitude;

            // If we're close enough to the target, stop
            if (distance < 0.1f)
            {
                isMoving = false;
                rb.linearVelocity = Vector2.zero;
            }
            else
            {
                // Normalize direction and apply velocity
                rb.linearVelocity = direction.normalized * speed;
            }
        }
    }

    // This method is called when you click (bind to your "Click" action)
    public void OnClick(InputAction.CallbackContext context)
    {
        // Only process when the mouse button is pressed (not released)
        if (context.performed)
        {
            // Convert mouse position to world position
            Vector2 mousePos = Mouse.current.position.ReadValue();
            targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
            isMoving = true;
        }
    }
}
/*public class PlayerMovement : Unit
{
    /*
    // Varaibles Used
    protected Vector2 m_Velocity;
    protected Vector3 m_LastPosition;

    [SerializeField] private Movement m_playerPos;
    public float CurrentSpeed => m_Velocity.magnitude;

    //Animation Variables
    private Animator animator;
    private Rigidbody2D rb;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
       m_LastPosition = transform.position;
       rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 
    /// </summary>
    protected void Update()
    {
        m_Velocity = new Vector2(
            (transform.position.x - m_LastPosition.x),
            (transform.position.y - m_LastPosition.y)
        ) / Time.deltaTime;

        m_LastPosition = transform.position;
        IsMoving = m_Velocity.magnitude > 0;

        animator.SetBool("isWalking", true);
    }
}*/
