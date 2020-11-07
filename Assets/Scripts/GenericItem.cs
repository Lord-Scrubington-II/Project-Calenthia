using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenericItem : ScriptableObject {

    public ItemType itemType;
    public int amount;

    // random items; subject to change
    // conenct each enum to a sprite to keep track
    public enum ItemType {
        HealthPotion,
        ManaPotion,
        Money
    }

}