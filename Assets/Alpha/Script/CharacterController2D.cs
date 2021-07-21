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

    //for fliping character
    public bool facingRight;

    public float force;
    //for pick up and drop
    public bool pickUp, carrying;
    public GameObject pickObj;
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
        PickingObject();
        if (carrying)
            DropObject();
        //transform.LookAt(camTarget.transform);
    }
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.transform.tag == "pushableObject" && hit != null /*&& Input.GetKeyDown(KeyCode.R)*/)
    //    {
    //        Vector3 dir = hit.transform.position - transform.position;
    //        dir = -dir.normalized;
    //        Rigidbody rb = hit.collider.attachedRigidbody;
    //        rb.isKinematic = false;
    //        rb.AddForce(dir * force);
    //        //if(rb != null)
    //        //{
    //        //    if(!rb.isKinematic && hit.moveDirection.y < 0.3)
    //        //    {

    //        //    }
    //        //}
    //    }
    //    else
    //    {
    //        Rigidbody rb = hit.collider.attachedRigidbody;
    //        rb.isKinematic = true;
    //    }
    //}
    private void PickingObject()
    {
        if (pickUp && pickObj.GetComponent<PushObject>().available)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                carrying = true;
                pickObj.transform.parent = gameObject.transform;
            }
        }
    }
    private void DropObject()
    {
            if (Input.GetKeyDown(KeyCode.C))
            {
                carrying = false;
                pickObj.transform.parent = null;
            }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pushableObject" && !carrying)
        {
            pickObj = other.gameObject;
            pickUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "pushableObject" && !carrying)
        {
            pickObj = null;
            pickUp = false;
        }
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
