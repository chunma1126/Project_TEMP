using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    
    private Animator animator;
    private readonly int MOVE = Animator.StringToHash("Move");
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        input.OnMovement += SetMoveAnimation;
    }

    private void SetMoveAnimation(Vector2 movement)
    {
        bool isMoving = movement.sqrMagnitude > 0; 
        animator.SetBool(MOVE, isMoving);
    }


}
