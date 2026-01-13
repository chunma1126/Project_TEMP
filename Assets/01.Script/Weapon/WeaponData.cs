using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "SO/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite weaponSprite;
    
    [Space(30)]
    public float radius;
    public float rotateSpeed;
    public float damage;
    public float knockbackPower;

}
