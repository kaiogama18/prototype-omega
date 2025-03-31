using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private SO_Inventory soInventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContanier");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    
    //public void SetInventory(Inventory inventory)
    //{
    //    this.inventory = inventory;
    //    inventory.OnItemListChanged += Inventory_OnItemListChanged;
    //    RefreshInventoryUI();
    //}

    private void Start()
    {
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
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

        foreach (SerializableDictionaryEntry<Item, int> entry in inventory.GetItemsList())
        //foreach (SerializableDictionaryEntry<Item, int> entry in soInventory.inventory)
        {

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("iconSprite").GetComponent<Image>();
            image.sprite = entry.item.sprite;

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();

            if (entry.amount > 1)
            {
                uiText.SetText(entry.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }

        }

        //foreach(Item item in inventory.GetItemsList())
        //{
        //    AddItemToInventoryUI(item, itemSlotCellSize, x, y);

            //    RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            //    itemSlotRectTransform.gameObject.SetActive(true);

            //    itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            //    Image image = itemSlotRectTransform.Find("iconSprite").GetComponent<Image>();
            //    image.sprite = item.GetItemSprite();

            //    TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            //    if (item.GetItemAmount() > 1)
            //    {
            //        uiText.SetText(item.GetItemAmount().ToString());
            //    }
            //    else
            //    {
            //        uiText.SetText("");
            //    }

            //    x++;
            //    if(x > 4)
            //    {
            //        x = 0;
            //        y++;
            //    }
            //}
    }
}
