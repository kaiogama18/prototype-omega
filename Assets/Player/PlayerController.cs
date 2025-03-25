using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public CharacterController controller;
    public Animator animations;

    void Start()
    {
        
    }

    void Update()
    {
        float side = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        Vector3 walk = transform.forward * forward + transform.right * side;

        controller.Move(speed * Time.deltaTime * walk);

        if( side !=0 )
        {
            this.transform.Rotate(0f, side, 0f, Space.World);
        }

        if( forward != 0 || side !=0 )
        {
            animations.SetBool("IsRunning", true);
        }
        else
        {
            animations.SetBool("IsRunning", false);
        }
    }
}
