using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.InputSystem;
using System.Linq;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventorySO : ScriptableObject
{
    public new string name;
    public int maxItensByLevel = 6;
    public int maxItens = 10;
    public int levelInventory = 1;

    [SerializeField]
    public List<SerializableDictionaryEntry<Item, int>> inventory;

    public void ClearDictionary()
    {
        inventory.Clear();
    }
    public void AddItemToDictionary(Drop drop, int amount)
    {
        Item item = drop.item;

        var itemFound = inventory.Find(
            entry => entry.item == item
            && entry.amount < maxItens
            && entry.item.rarity == item.rarity
            );

        if (itemFound != null && itemFound.item.itemType != Item.ItemType.weapon)
        {
            itemFound.amount += amount;
            drop.OnDestroyItem();
        }

        else
        {
            if (inventory.Count < maxItensByLevel)
            {
                inventory.Add(new SerializableDictionaryEntry<Item, int>
                {
                    item = item,
                    amount = amount
                });

                drop.OnDestroyItem();
            }
            else
            {
                Debug.Log("Mochila Cheia");
            }

        }
    }

    public Dictionary<Item, int> GetItemDictionary()
    {
        Dictionary<Item, int> dictionary = new Dictionary<Item, int>();

        foreach (var item in inventory)
        {
            dictionary.Add(item.item, item.amount);
        }

        return dictionary;
    }
}