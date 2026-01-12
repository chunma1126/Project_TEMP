using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    private const float EVASION_SCALE = 40;
    private const float DAMAGE_INTERVAL_TIME = 0.1f;
    
    [SerializeField] private PlayerData playerData;
    private float lastDamageTime;
    
    public Action OnEvasion;
        
    
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

        if (Time.time < lastDamageTime + DAMAGE_INTERVAL_TIME)
        {
            return;
        }
        
        playerData.CurrentHealth -= finalDamage;
        
        lastDamageTime = Time.time;
            
        if (playerData.CurrentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
    }
    
}
