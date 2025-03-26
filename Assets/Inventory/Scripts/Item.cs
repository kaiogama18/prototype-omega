using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Fish,
        Rock,
        Sword
    }

    public ItemType itemType;
    public int amount;

    //public Sprite GetSprite()

    //public Color GetColor()

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Fish:
            case ItemType.Rock:
                return true;
            case ItemType.Sword:
                return false;
        }
    }
}
