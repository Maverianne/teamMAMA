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

    public bool facingRight;



    public Vector3 moveDirection;
    private void Start()
    {
        charSprite.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Movement();
        Rotate();
        Flip();
        //transform.LookAt(camTarget.transform);
    }
    private void Flip()
    {
        float horizontalVal = Input.GetAxis("Horizontal");
        if((horizontalVal < 0 && facingRight) || (horizontalVal > 0 && !facingRight))
        {
            facingRight = !facingRight;
            charSprite.transform.Rotate(new Vector3(0, 180, 0));
        }
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

        camForward = camTrans.transform.forward;
        camForward.y = 0;
        camForward = camForward.normalized;
        
        moveDirection = (x * camTrans.right + z * camForward).normalized;

        //direction
        moveDirection *= speed;
        //gravity
        moveDirection.y += verticalSpeed;
        //movement
        charControl.Move(moveDirection * Time.deltaTime);
    }
}
