using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeController : MonoBehaviour, IInteractable
{
    GameObject popup;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            popup.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        popup.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
