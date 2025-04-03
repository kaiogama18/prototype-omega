using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private CharacterController controller;
    
    [SerializeField] private float moveSpeed = 7f;
    //[SerializeField] private float rotateSpeed = 10f;
    
    private IInteractable currentInteractable = null;

    private bool isWalking;


    void Update()
    {
        #region Player Movement

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
        controller.Move(moveDir * moveSpeed * Time.deltaTime); //transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;
        //transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        #endregion

        #region Player Interact

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }

        #endregion

    }

    public bool IsWalking()
    {
        return isWalking;
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

}
