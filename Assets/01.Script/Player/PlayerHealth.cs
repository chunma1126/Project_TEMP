using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    private const float EVASION_SCALE = 40;
    
    private float lastDamageTime;
    
    [SerializeField] private PlayerData playerData;
    
    public UnityEvent OnEvasionEvent;
    public UnityEvent OnHitEvent;
        
    private void Awake()
    {
        playerData.CurrentHealth = playerData.MaxHealth;
    }
    
    public void TakeDamage(ActionData actionData)
    {
        float finalDamage = actionData.damage * (actionData.damage / (actionData.damage + playerData.Defense));
        float dodgeRate = playerData.Evasion / (playerData.Evasion + EVASION_SCALE);

        if (dodgeRate > Random.value)//success Evasion
        {
            return;
        }

        if (Time.time < lastDamageTime + playerData.InvincibleTime)//InvincibleTime
        {
            return;
        }
                
        playerData.CurrentHealth -= finalDamage;
        lastDamageTime = Time.time;
            
        OnHitEvent?.Invoke();
        
        if (playerData.CurrentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
    }
    
}
