using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon", order = 1)]
public class Weapon : GenericItem
{
    public string weaponName;
    public string weaponDesc;

    public int atk;
    public int matk;

    public Sprite artwork;
}
