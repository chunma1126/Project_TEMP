using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D collider;
    private float angle;
    
    public WeaponData WeaponData;
    
    private void Awake()
    {
        player = transform.parent;
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        SetWeaponData();

    }

    private void SetWeaponData()
    {
        gameObject.name = WeaponData.weaponName;
        spriteRenderer.sprite = WeaponData.weaponSprite;

        collider.size = WeaponData.colliderSize;
        collider.offset = WeaponData.colliderOffset;
    }

    public void Move(int index, int totalCount)
    {
        float baseAngle = 360f / totalCount * index;

        angle += WeaponData.rotateSpeed * Time.deltaTime;
        float finalAngle = angle + baseAngle;

        float rad = finalAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * WeaponData.radius;

        transform.localPosition = offset;
        transform.localRotation = Quaternion.Euler(0f, 0f, finalAngle + 270f);

        spriteRenderer.sortingOrder =
            transform.position.y > player.position.y ? -1 : 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            ActionData data = new ActionData();
            data.damage = WeaponData.damage;
            data.dealer = transform;
            data.knockbackDirection = (other.transform.position - player.position).normalized;
            data.knockbackPower = WeaponData.knockbackPower;

            damageable.TakeDamage(data);
        }
    }

}
