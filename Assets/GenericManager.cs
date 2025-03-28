using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class GenericManager : MonoBehaviour
{
    //[SerializeField] private List<GameObject> propMeshes = new List<GameObject>();

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
            //Debug.Log("DropItemById: " + id + " -> " + item.itemType );
            //Actions.AddItemToInventory?.Invoke(new Item { itemType = Item.ItemType.consumable, itemAmount = 1 });
        }
    }
}
