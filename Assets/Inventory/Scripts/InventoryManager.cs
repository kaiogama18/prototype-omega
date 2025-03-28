using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public event EventHandler OnItemListChanged;
    
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private Player player;
    [SerializeField] private float moveToPlayerDuration = .25f;
    
    [SerializeField, HideInInspector] private List<Item> itemList;
    private Vector3 playerPosition; 

    private void Start()
    {
        uiInventory.SetInventory(this);
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
                if (inventoryItem.itemType == item.itemType)
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

}
