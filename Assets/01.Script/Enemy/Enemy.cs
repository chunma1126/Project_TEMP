using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyAnimationController animationController;
    private Visualizer visualizer;
    private EnemyHealth health;

    private Vector2 movement;
    private readonly Collider2D[] closeEnemies = new Collider2D[25];

    public Transform Player;
    public float moveSpeed = 3f;
    public float separationDistance = 1f;
    public float separationForce = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<EnemyAnimationController>();
        visualizer = GetComponent<Visualizer>();
        health = GetComponent<EnemyHealth>();
    }

    private void FixedUpdate()
    {
        if (Player == null || health.isKnockback) return;

        Vector2 dirToPlayer = (Player.position - transform.position).normalized;

        Vector2 desired = dirToPlayer * moveSpeed + GetSeparationDir() * separationForce;

        rb.linearVelocity = desired;
        animationController.SetMoveAnimation(desired);
        visualizer.Flip(desired);
    }

    private Vector2 GetSeparationDir()
    {
        Vector2 separation = Vector2.zero;

        var size = Physics2D.OverlapCircleNonAlloc(transform.position, separationDistance, closeEnemies);
        if (size > 0)
        {
            foreach (var hit in closeEnemies)
            {
                if (hit != null && hit.transform != transform && hit.CompareTag("Enemy"))
                {
                    Vector2 away = (Vector2)(transform.position - hit.transform.position);
                    float dist = away.magnitude;
                    separation += away.normalized / dist;
                }
            }
        }

        return separation;
    }

}
