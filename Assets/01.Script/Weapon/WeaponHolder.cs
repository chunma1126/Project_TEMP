using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponList;

    private void Update()
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponList[i].Move(i, weaponList.Count);
        }
    }
    
}
