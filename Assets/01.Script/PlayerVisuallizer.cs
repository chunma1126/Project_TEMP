using System;
using UnityEngine;

public class PlayerVisuallizer : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    
    private SpriteRenderer spriteRenderer;
    private bool isRight = true;
    
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        input.MovementCallback += Flip;
    }

    private void Flip(Vector2 direction)
    {
        if (direction.x > 0 && !isRight)
        {
            spriteRenderer.flipX = false;
            isRight = true;
        }
        else if (direction.x < 0 && isRight)
        {
            spriteRenderer.flipX = true;
            isRight = false;
        }
        
    }
        
}
