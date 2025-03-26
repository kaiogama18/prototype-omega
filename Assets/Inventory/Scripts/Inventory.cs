using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory: MonoBehaviour
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        
        //AddItem(new Item { itemType = Item.ItemType.Fish, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Rock, amount = 4 });
        //AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
    }

    public void AddItem(Item item)
    {

        Debug.Log("Item Dropado amount: " + item.amount);
        Debug.Log("Item Dropado itemType: " + item.itemType);

        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            
            foreach(Item inventoryItem in itemList)
            {
                if(inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            
            if(!itemAlreadyInInventory)
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
