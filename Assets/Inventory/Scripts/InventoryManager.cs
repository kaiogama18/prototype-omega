using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager 
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;

    public InventoryManager()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {

        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;

            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.itemAmount += item.itemAmount;
                    itemAlreadyInInventory = true;
                }
            }

            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }

        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemsList()
    {
        return itemList;
    }
}
