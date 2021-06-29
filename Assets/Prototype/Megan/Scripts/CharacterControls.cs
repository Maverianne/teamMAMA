using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    //setup for movement
    public CharacterController CharControl;
    public float Speed;

    //setup for gravity
    public float Gravity;
    public float VerticalSpeed;


    public Vector3 moveDirection;

    void Update()
    {
        //this stuff happens
        Move();
       
    }
    
    //The actual movement using the character controller
    private void Move()
    {
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");

        //gravity
        if (CharControl.isGrounded)
        {
            VerticalSpeed = 0;
        }
        else
        {
            VerticalSpeed -= Gravity * Time.deltaTime;
        }
        Vector3 gravityMove = new Vector3(0, VerticalSpeed, 0);

        //rotate to look at movement direction
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDirection != Vector3.zero) transform.rotation = Quaternion.LookRotation(moveDirection);
        
        //direction
        moveDirection *= Speed;
        //gravity
        moveDirection.y += VerticalSpeed;
        //movement
        CharControl.Move(moveDirection * Time.deltaTime);
    }

}
