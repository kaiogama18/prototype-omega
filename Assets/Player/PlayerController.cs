using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public CharacterController controller;
    public Animator animations;
    public float rotationPower = 1f;

    void Start()
    {
        
    }

    void Update()
    {
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


        #region Player Interact

        if (Input.GetKeyDown(KeyCode.E))
        {
            float interctRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interctRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.CompareTag("Player"))
                {
                    continue;
                }

                Debug.Log("Collider está na posição do objeto: -> " + collider);
                
                //if(collider != null && collider.bounds.Contains(transform.position))
                //{
                //  Debug.Log("Collider está na posição do objeto: -> " + collider);
                //}
            }
        }
        #endregion

    }
}
