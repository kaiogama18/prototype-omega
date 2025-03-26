using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeController : MonoBehaviour, IInteractable
{
    private Item item;

    public void Interact()
    {
        //Debug.Log("Item sendo Interagido: " + gameObject.name);

        Actions.OnDropItem?.Invoke(1);
    }
}
