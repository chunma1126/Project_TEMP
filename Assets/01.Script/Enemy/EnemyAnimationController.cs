using System;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class EnemyAnimationController : MonoBehaviour
{
    private readonly int MOVE = Animator.StringToHash("Move");
    private readonly int DEAD = Animator.StringToHash("Dead");
    
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetDeadAnimation()
    {
        animator.SetTrigger(DEAD);
    }
    
    public void SetMoveAnimation(Vector2 direction)
    {
        if (direction.sqrMagnitude <= 0)
        {
            animator.SetBool(MOVE , false);
        }
        
        animator.SetBool(MOVE, true);
    }    
        
}