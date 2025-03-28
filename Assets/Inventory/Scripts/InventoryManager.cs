using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class InventoryManager : MonoBehaviour
{
    public event EventHandler OnItemListChanged;
    
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private Player player;
    [SerializeField] private float moveToPlayerDuration = .25f;
    [SerializeField, HideInInspector] private List<Item> itemList;

    [SerializeField] private int inventoryLevel = 1;

    [SerializeField, HideInInspector] private int inventorySlots; 

    [SerializeField] private int maxItens = 10;
    private Vector3 playerPosition; 

    private void Start()
    {
        
        uiInventory.SetInventory(this);

        switch(inventoryLevel)
        {
            default:
            case 1:
                inventorySlots = 6;
                break;
            case 2:
                inventorySlots = 12;
                break;
            case 3:
                inventorySlots = 24;
                break;
        }

        itemList = new List<Item>(inventorySlots);

    }

    private void Update()
    {
        playerPosition = player.transform.position;
    }

    private void OnEnable()
    {
        Actions.AddItemToInventory += AddItemToInventory; 
    }

    private void OnDisable()
    {
        Actions.AddItemToInventory -= AddItemToInventory;  
    }
   
    public void AddItemToInventory(Item item)
    {
        
        StartCoroutine(MoveItemToPlayer(item));
    }


    IEnumerator MoveItemToPlayer(Item item)
    {
        Vector3 startPosition = item.transform.position;

        float timeElapsed = 0f;

        while (timeElapsed < moveToPlayerDuration)
        {
            item.transform.position = Vector3.Lerp(startPosition, new Vector3(playerPosition.x, 1f , playerPosition.z), timeElapsed / moveToPlayerDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        item.transform.position = playerPosition;
        UpdateUIInventory(item);
    }

    private void UpdateUIInventory(Item item)
    {
        item.SetItemAmount(1);
        
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;

            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType
                    && inventoryItem.itemName == item.itemName
                    && inventoryItem.itemRarity == item.itemRarity 
                    && inventoryItem.GetItemAmount() < maxItens)
                {
                    inventoryItem.SetItemAmount(item.GetItemAmount());
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

        item.DestroyItem();
    }



    public List<Item> GetItemsList()
    {
        return itemList;
    }

    public int GetInventorySlots()
    {
        return inventorySlots;
    }

}
