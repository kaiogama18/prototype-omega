using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnItemListChanged;

    [SerializeField] private InventorySO soInventory;
    [SerializeField] private UI_Inventory uiInventory;

    [SerializeField] protected UIDocument inventoryUI;

    protected Button btnClose;
    protected VisualElement root;
    protected VisualElement slotContainer;

    protected int size;

    //private IEnumerator InitializeView(int size = 20);

    private void OnEnable()
    {
        Actions.OpenInventoryUI += OpenInventoryUI;
        Actions.AddItemToInventory += AddItemToInventory;
    }
    
    private void OnDisable()
    {
        Actions.OpenInventoryUI -= OpenInventoryUI;
        Actions.AddItemToInventory -= AddItemToInventory;

        if (btnClose != null)
            btnClose.UnregisterCallback<ClickEvent>(OnClose);
    }


    private void Awake()
    {
        soInventory.ClearDictionary();
        size = 12;
    }

    //private void Start()
    //{
    //    uiInventory.SetInventory(this);
    //}

    public void OpenInventoryUI()
    {
        inventoryUI.transform.gameObject.SetActive(true);
        
        btnClose = inventoryUI.rootVisualElement.Q("BtnClose") as Button;
        btnClose.RegisterCallback<ClickEvent>(OnClose);
    }


    public void OnClose(ClickEvent evt)
    {
        inventoryUI.transform.gameObject.SetActive(false);
    }

    public void AddItemToInventory(Drop drop)
    {
        soInventory.AddItemToDictionary(drop, 1);
        UpdateUIInventory();
    }

    public virtual void UpdateUIInventory()
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
