using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Camera camTarget;
    public GameObject charSprite;


    //setup for movement
    public CharacterController charControl;
    public float speed;

    //setup for gravity
    public float gravity;
    public float verticalSpeed;


    public Vector3 moveDirection;
    private void Start()
    {
        charSprite.GetComponent<CharacterController>();
    }
    private void Update()
    {
        charSprite.transform.LookAt(camTarget.transform);
        Movement();
    }

    public void Movement()
    {

        //gravity
        if (charControl.isGrounded)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        moveDirection = new Vector3(x, 0, z);
        //moveDirection = camTarget.transform.TransformDirection(x,0,z);

        //direction
        moveDirection *= speed;
        //gravity
        moveDirection.y += verticalSpeed;
        //movement
        charControl.Move(moveDirection * Time.deltaTime);
    }
}
