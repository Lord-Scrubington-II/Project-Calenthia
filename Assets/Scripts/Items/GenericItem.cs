
﻿using UnityEngine;
public abstract class GenericItem : ScriptableObject{


    public ItemType itemType;
    public string itemName;
    public string description;
    public int amount;

    // random items; subject to change
    // conenct each enum to a sprite to keep track
    public enum ItemType {
        HealthPotion,
        ManaPotion,
        Money,
        Weapon,
        Armor
    }

}