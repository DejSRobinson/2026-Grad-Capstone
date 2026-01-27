using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    [SerializeField] public Movement m_player;
    private SpriteRenderer m_spriteRenderer;
    public bool IsMoving;

    protected Animator m_Animator;

    protected void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (TryGetComponent<Animator>(out var animator))
        {
            m_Animator = animator;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="destination"></param>
    public void MoveTo(Vector3 destination)
    {
        var dir = (destination - transform.position).normalized;
        m_spriteRenderer.flipX = dir.x < 0;
        m_player.SetDestination(destination);
    }
}
