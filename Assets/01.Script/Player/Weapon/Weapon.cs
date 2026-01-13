using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private float angle;


    [SerializeField] private float radius = 2.5f;
    [SerializeField] private float rotateSpeed = 180f;

    private void Awake()
    {
        player = transform.parent;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move()
    {
        angle += rotateSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;
        transform.localPosition = offset;
        transform.localRotation = Quaternion.Euler(0f, 0f, angle + 270f);

        if (transform.position.y > player.position.y)
        {
            spriteRenderer.sortingOrder = -1;
        }
        else
        {
            spriteRenderer.sortingOrder = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            ActionData data = new ActionData();
            data.damage = 10;
            data.dealer = transform;
            data.knockbackDirection = (other.transform.position - player.position).normalized;
            data.knockbackPower = 4;

            damageable.TakeDamage(data);
        }
    }

}
