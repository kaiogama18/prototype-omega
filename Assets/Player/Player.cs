using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    
    
    public float speed = 5f;
    public CharacterController controller;
    public Animator animations;

    public float rotationPower = 1f;
    public float interactionRange = 3f;
    private IInteractable currentInteractable = null;

    private Inventory inventory;


    private void OnEnable()
    {
        Actions.AddItemOnInventory += AddItemOnInventory;
    }

    private void OnDisable()
    {
        Actions.AddItemOnInventory -= AddItemOnInventory;
    }


    private void Awake()
    {
        #region Inventory

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
        #endregion
    }

    void Update()
    {
        #region Player Movement

        float side = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");
        
        Vector3 walk = transform.forward * forward + transform.right * side;

        controller.Move(speed * Time.deltaTime * walk);


        if( forward != 0 || side !=0 )
        {
            animations.SetBool("IsRunning", true);
        }
        else
        {
            animations.SetBool("IsRunning", false);
        }

        #endregion

        #region Player Interact
        
        if(Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }

        #endregion

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            IInteractable interactable = other.GetComponent<IInteractable>();
            if(interactable != null)
            {
                currentInteractable = interactable;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            currentInteractable = null;
        }
    }

    public void AddItemOnInventory(Item item)
    {
        inventory.AddItem(item);
    }

}
