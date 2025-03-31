using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item: ScriptableObject
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

    public new string name;
    public Mesh staticMesh;
    public Sprite sprite;
    public ItemType itemType;
    public ItemRarity rarity;
    
    [HideInInspector] public int amount = 0;
    
    public float rotationSpeed = 100f;
    public bool isDestructive = false;
    
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

    public Sprite GetItemSprite()
    {
        return sprite;
    }

    public int GetItemAmount()
    {
        return amount;
    }

    public void SetItemAmount(int amount)
    {
        this.amount += amount;
    }
}
