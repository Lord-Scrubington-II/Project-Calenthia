using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon", order = 1)]
public class Weapon : EquippableItem
{
    public WeaponType weaponType;
    
    public enum WeaponType {
        broadsword,
        staff,
        crossbow,
        etc
    }
}
