using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Items/Armor", order = 1)]
public class Armor : EquippableItem
{
    public ArmorType armorType;

    public enum ArmorType {
        lightarmor,
        heavyarmor,
        robe,
        etc
    }
}
