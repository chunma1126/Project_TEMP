using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyAnimationController animationController;
    private Visualizer visualizer;

    private Vector2 movement;
    
    public Transform Player;
    public float moveSpeed = 3f;
    public float separationDistance = 1f;
    public float separationForce = 2f;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<EnemyAnimationController>();
        visualizer = GetComponent<Visualizer>();
    }
    
    private void FixedUpdate()
    {
        if (Player == null) return;

        Vector2 dirToPlayer = (Player.position - transform.position).normalized;

        Vector2 separation = Vector2.zero;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, separationDistance);

        foreach (var hit in hits)
        {
            if (hit != null && hit.transform != transform && hit.CompareTag("Enemy"))
            {
                Vector2 away = (Vector2)(transform.position - hit.transform.position);
                float dist = Mathf.Max(away.magnitude, 0.3f);
                separation += away.normalized / dist;
            }
        }

        Vector2 desired =
            dirToPlayer * moveSpeed +
            separation * separationForce;

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desired, 0.2f);

        animationController.SetMoveAnimation(rb.linearVelocity);
        visualizer.Flip(rb.linearVelocity);
    }
}
