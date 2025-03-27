using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("O Inimigo foi de F!!");


        Actions.OnDropItem?.Invoke(2);
    }
}
