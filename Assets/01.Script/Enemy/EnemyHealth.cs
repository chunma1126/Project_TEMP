using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private float currentHealth = 100;
    private Material originalMaterial;
    private WaitForSeconds hitDelay;
        
    [SerializeField] private Material hitMaterial;

    public bool isKnockback;
    

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        
        hitDelay = new WaitForSeconds(0.1f);
    }

    private void Start()
    {
        
    }

    public void TakeDamage(ActionData actionData)
    {
        currentHealth -= actionData.damage;

        rigidbody2D.linearVelocity = Vector2.zero;
        rigidbody2D.linearVelocity =  actionData.knockbackDirection * actionData.knockbackPower;
        
        StartCoroutine(CoHitRoutine());

        if (currentHealth <= 0)
        {
            Dead();
        }
        
    }

    public void Dead()
    {
        
    }

    private IEnumerator CoHitRoutine()
    {
        isKnockback = true;
        spriteRenderer.material = hitMaterial;
        yield return hitDelay;

        isKnockback = false;
        spriteRenderer.material = originalMaterial;
    }  
}
