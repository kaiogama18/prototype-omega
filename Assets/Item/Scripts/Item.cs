using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{
    public enum ItemType
    {
        consumable,
        normal,
        weapon
    }

    public enum ItemRarity
    {
        common,
        rare,
        legendary,
        special
    }

    [SerializeField, HideInInspector] private int itemID;
    public string itemName;
    [SerializeField] private Sprite itemSprite;
    public ItemType itemType;
    public ItemRarity itemRarity;
    private int itemAmount = 0;

    //[SerializeField] private float itemLifetime = 100f;
    private float blinkDuration = 5f;
    private bool isBlinking = false;

    [SerializeField, HideInInspector] private float rotationSpeed = 100f;

    public bool IsStackable()
    {

        switch (itemType)
        {
            default:
            case ItemType.consumable:
            case ItemType.normal:
                return true;
            case ItemType.weapon:
                return false;
        }
    }

    private void Start()
    {
        gameObject.SetActive(true);
        //Invoke("StartBlinking", itemLifetime - blinkDuration);
        //Destroy(gameObject, itemLifetime);
    }

    private void Update()
    {
        this.transform.Rotate(Vector3.up, (rotationSpeed * 2) * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Actions.AddItemToInventory(this);
            //Destroy(gameObject);
        }
    }

    


    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void StartBlinking()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkEffect());
        }
    }

    private IEnumerator BlinkEffect()
    {
        isBlinking = true;
        float flashInterval = 0.1f;
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            gameObject.SetActive(!gameObject.activeSelf);
            elapsedTime += flashInterval;
            yield return new WaitForSeconds(flashInterval);
        }

        gameObject.SetActive(true);
    }


    public Sprite GetItemSprite()
    {
        return itemSprite;
    }

    public int GetItemAmount()
    {
        return itemAmount;
    }

    public void SetItemAmount(int amount)
    {
        itemAmount += amount;
    }
}
