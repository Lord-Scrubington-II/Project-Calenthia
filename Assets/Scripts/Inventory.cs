using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private List<GenericItem> itemList;

    public Inventory()
    {
        itemList = new List<GenericItem>();
    }

    // Getter for class.
    public List<GenericItem> GetItemList()
    {
        return itemList;
    }

    // Adds an item to the inventory.
    public void AddItem(GenericItem item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(GenericItem item)
    {
        itemList.Remove(item);
    }

}
