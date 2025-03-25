using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public void OnTriggerEnter(Collider other);
    public void OnTriggerExit(Collider other);
}

//interface IInteractable
//{
//    public void Interact();
//}

//public class Interactable : MonoBehaviour
//{
//    public Transform InteractorSource;
//    public float InteractRange;

//    void Start()
//    {

//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
//            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
//            {
//                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObj))
//                {
//                    interactableObj.Interact();
//                }
//            }
//        }
//    }
//}