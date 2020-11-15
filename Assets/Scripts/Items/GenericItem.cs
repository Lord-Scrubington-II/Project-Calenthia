
﻿using UnityEngine;
public abstract class GenericItem : ScriptableObject{


    public ItemType itemType;
    public int amount;
    public string description;
    public string itemName;

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