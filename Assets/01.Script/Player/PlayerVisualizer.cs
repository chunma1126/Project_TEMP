using System;
using UnityEngine;

public class PlayerVisualizer : Visualizer
{
    [SerializeField] private PlayerInput input;
    
    protected override void Awake()
    {
        base.Awake();
        input.OnMovement += Flip;
    }
            
}
