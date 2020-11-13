using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Items/Armor", order = 1)]
public class Armor : GenericItem
{
    public string armorName;
    public string armorDesc;

    public int def;
    public int mdef;

    public Sprite artwork;
}
