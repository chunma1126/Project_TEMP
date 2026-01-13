using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponList;

    private void Update()
    {
        foreach (var item in weaponList)
        {
            item.Move();
        }
    }
    
}
