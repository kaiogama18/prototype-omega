using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StorageManager : MonoBehaviour, IInteractable
{
    [SerializeField] private UIDocument storageUI;
    private Button btnClose;
    
    public void Interact()
    {
        if(storageUI == null)
        {
            storageUI = GetComponent<UIDocument>();
        }
        
        storageUI.transform.gameObject.SetActive(true);
        
        btnClose = storageUI.rootVisualElement.Q("BtnClose") as Button;
        btnClose.RegisterCallback<ClickEvent>(OnClose);
    }
    private void OnDisable()
    {
        if(btnClose != null)
            btnClose.UnregisterCallback<ClickEvent>(OnClose);
    }

    public void OnClose(ClickEvent evt)
    {
        storageUI.transform.gameObject.SetActive(false);
        OnDisable();
    }

}
