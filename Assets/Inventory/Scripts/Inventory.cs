using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnItemListChanged;

    [SerializeField] private SO_Inventory soInventory;
    [SerializeField] private UI_Inventory uiInventory;
    private void Awake()
    {
        soInventory.ClearDictionary();
    }

    //private void Start()
    //{
    //    uiInventory.SetInventory(this);
    //}

    public void AddItemToInventory(Drop drop)
    {
        soInventory.AddItemToDictionary(drop, 1);

        UpdateUIInventory();
    }

    public void UpdateUIInventory()
    {
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<SerializableDictionaryEntry<Item, int>> GetItemsList()
    {
        return soInventory.inventory;
    }

    public int GetInventorySlots()
    {
        return soInventory.maxItensByLevel;
    }


}
