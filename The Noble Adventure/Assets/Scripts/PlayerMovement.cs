using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement:MonoBehaviour
{
    // Varaibles Used
    [SerializeField] protected float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isMoving = false;
    public GameObject indicator;
    public Collider2D collision;

    /// <summary>
    /// Sets up our game variables 
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        indicator.SetActive(false);
    }

    private void Update()
    {
        // If we're moving and not at the target, move towards it
        if (isMoving)
        {
            indicator.SetActive(true);
            indicator.transform.position = targetPosition;

            // Calculate direction and distance
            Vector2 direction = targetPosition - (Vector2)transform.position;
            float distance = direction.magnitude;

            // If we're close enough to the target, stop
            if (distance < 0.1f)
            {
                isMoving = false;
                rb.linearVelocity = Vector2.zero;
                indicator.SetActive(false);
            }
            else
            {
                // Normalize direction and apply velocity
                rb.linearVelocity = direction.normalized * speed;
            }
        }
    }

    // This method is called when you click a location on the map
    public void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        // Only process when the mouse button is pressed (not released)
        if (context.performed)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.tag == "Chest")
                {
                    Debug.Log("Opening Chest");
                }
            }
            
            else
            {
                // Convert mouse position to world position
                targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
                isMoving = true;
                Debug.Log("Moving to " + targetPosition);
            }
        }
    }
}