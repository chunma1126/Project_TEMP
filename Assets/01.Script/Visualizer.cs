using UnityEngine;

public class Visualizer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isRight = true;
    
    protected virtual void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    public void Flip(Vector2 direction)
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