using UnityEngine;
using System;

public class PlayerMovement : Unit
{
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
}
