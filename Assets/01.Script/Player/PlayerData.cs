using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Action<float> OnMoveSpeedChange;
    public Action<float> OnMaxHealthChange;
    public Action<float> OnHealthChange;
    public Action<float> OnDefenseChange;
    public Action<float> OnEvasionChange;
    
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float defense;
    [SerializeField] private float evasion;
    
    public float MoveSpeed
    {
        get => moveSpeed;
        set
        {
            if (Mathf.Approximately(moveSpeed, value)) return;
            moveSpeed = value;
            OnMoveSpeedChange?.Invoke(moveSpeed);
        }
    }

    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            if (Mathf.Approximately(maxHealth, value)) return;
            maxHealth = value;
            OnMaxHealthChange?.Invoke(maxHealth);

            CurrentHealth = Mathf.Min(currentHealth, maxHealth);
        }
    }

    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            float newValue = Mathf.Clamp(value, 0f, maxHealth);
            if (Mathf.Approximately(currentHealth, newValue)) return;
            currentHealth = newValue;
            OnHealthChange?.Invoke(currentHealth);
        }
    }
    
   

    public float Defense
    {
        get => defense;
        set
        {
            if (Mathf.Approximately(defense, value)) return;
            defense = value;
            OnDefenseChange?.Invoke(defense);
        }
    }

    public float Evasion
    {
        get => evasion;
        set
        {
            if (Mathf.Approximately(evasion, value)) return;
            evasion = value;
            OnEvasionChange?.Invoke(evasion);
        }
    }

}