using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class GenericManager : MonoBehaviour
{
    //private Inventory inventory;
    //[SerializeField] private Player player;

    //private void Awake()
    //{
    //    inventory = new Inventory();
    //}

    private void OnEnable()
    {
        Actions.OnDropItem += DropItemById;
    }

    private void OnDisable()
    {
        Actions.OnDropItem -= DropItemById;
    }

    private void DropItemById(int id)
    {
        if(id == 1)
        {

            //Item item = new Item { itemType = Item.ItemType.Fish, amount = 1 };
            //Debug.Log("DropItemById: " + id + " -> " + item.itemType );
            
            Actions.AddItemOnInventory?.Invoke(new Item { itemType = Item.ItemType.Fish, amount = 1 });
        }
    }
}
