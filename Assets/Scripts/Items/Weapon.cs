using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon", order = 1)]
public class Weapon : GenericItem
{
    public string weaponName;
    public string weaponDesc;

    public uint atk;
    public uint matk;

    public Sprite artwork;
}
