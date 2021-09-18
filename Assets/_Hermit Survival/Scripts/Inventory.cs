using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem {
    public ItemSO.ItemType itemType;
    public int amountInInventory;
}

public class Inventory {

#region Public Fields
    public List<InventoryItem> listOfItems;
    public float weight;

    public Inventory() {
        listOfItems = new List<InventoryItem>();
        weight = 0;
    }
    // public List<Resource> listOfResources;
#endregion

#region Private Serializable Fields

#endregion

#region Private Fields

#endregion

#region Private Methods

#endregion

#region Public Methods
    // public void AddResource(ResourceSO resource, int amount) {
    //     if(listOfResources == null) {
    //         listOfResources = new List<ResourceSO.ResourceType>();
    //     }
    // }
    public void AddItem(Item item) {
        if(item.itemData.isStackable) {
            int index = listOfItems.FindIndex(0, listOfItems.Count - 1, (x) => x.itemType == item.itemData.itemType);
            if(index >= 0) {
                listOfItems[index].amountInInventory += 1;
            }
        } else {
            InventoryItem invItem = new InventoryItem() { itemType = item.itemData.itemType, amountInInventory = 1 };
            listOfItems.Add(invItem);
        }
    }
#endregion
}