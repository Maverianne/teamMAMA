using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Camera camTarget;
    public GameObject charSprite;
    public Transform camTrans;
    public Vector3 camForward;


    //setup for movement
    public CharacterController charControl;
    public float speed;

    //setup for gravity
    public float gravity;
    public float verticalSpeed;

    //public GameObject targetObj;
    //private float targetAngle = 0;
    //const float rotationAmount = 2.5f;

    //public bool rotating;



    public Vector3 moveDirection;
    private void Start()
    {
        charSprite.GetComponent<CharacterController>();
    }
    private void Update()
    {
        Movement();
        Rotate();
    }

    private void Rotate()
    {
        Vector3 targetVector = camTarget.transform.position - transform.position;
        float newYAngle = Mathf.Atan2(targetVector.x, targetVector.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, newYAngle, 0);
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

        camTrans = camTarget.transform;

        // camForward = Vector3.Scale(camTrans.forward, new Vector3(1, 0, 1)).normalized;
        camForward = camTrans.transform.forward;
        camForward.y = 0;
        camForward = camForward.normalized;
        
        moveDirection = (x * camTrans.right + z * camForward).normalized;
        //moveDirection = camTarget.transform.TransformDirection(x,0,z);

        //direction
        moveDirection *= speed;
        //gravity
        moveDirection.y += verticalSpeed;
        //movement
        charControl.Move(moveDirection * Time.deltaTime);
    }
}
