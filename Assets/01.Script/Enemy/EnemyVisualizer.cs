using UnityEngine;

public class EnemyVisualizer : Visualizer
{
    private const float FLIP_INTERVAL = 0.15F;
    
    private float lastFlipTime;

    public override void Flip(Vector2 direction)
    {
        if (Time.time >  lastFlipTime + FLIP_INTERVAL)
        {
            return;
        }
        
        base.Flip(direction);
        lastFlipTime = Time.time;
    }
}