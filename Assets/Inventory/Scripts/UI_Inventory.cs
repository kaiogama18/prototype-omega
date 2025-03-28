using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UI_Inventory : MonoBehaviour
{
    private InventoryManager inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContanier");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    public void SetInventory(InventoryManager inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        
        RefreshInventoryUI();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryUI();
    }

    private void RefreshInventoryUI()
    {

        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = inventory.GetInventorySlots();

        foreach(Item item in inventory.GetItemsList())
        {
            AddItemToInventoryUI(item, itemSlotCellSize, x, y);

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("iconSprite").GetComponent<Image>();
            image.sprite = item.GetItemSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.GetItemAmount() > 1)
            {
                uiText.SetText(item.GetItemAmount().ToString());
            }
            else
            {
                uiText.SetText("");
            }

            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }

    private void AddItemToInventoryUI(Item item, float itemSlotCellSize, int x, int y)
    {

        

    }
}
