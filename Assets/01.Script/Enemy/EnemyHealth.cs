using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    private float currentHealth = 100;

    public UnityEvent<ActionData> OnHitEvent;
    
    private void Awake()
    {
    }

    private void Start()
    {
        
    }

    public void TakeDamage(ActionData actionData)
    {
        currentHealth -= actionData.damage;
        
        OnHitEvent?.Invoke(actionData);

        if (currentHealth <= 0)
        {
            Dead();
        }
        
    }

    public void Dead()
    {
        
    }
   
}
