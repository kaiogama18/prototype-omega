using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionaryEntry<Item, TValue>
{
    public Item item;
    public TValue amount;
}
