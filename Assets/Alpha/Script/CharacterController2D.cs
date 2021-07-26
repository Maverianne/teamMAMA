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
    public Animator anim;
    public float speed;

    //setup for gravity
    public float gravity;
    public float verticalSpeed;

    //for fliping character
    public bool facingRight;

    //for pick up and drop
    public bool pickUp, carrying, facingforward;
    public GameObject pickObj;
    public GameObject pickUpper;
    public Vector3 moveDirection;
    private void Start()
    {
        anim = charSprite.GetComponent<Animator>();
    }
    private void Update()
    {
        Movement();
        Rotate();
        Flip();
        PickingObject();
    }
    private void PickingObject()
    {
        if (pickUp && pickObj.GetComponent<PushObject>().available)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                carrying = true;
                pickObj.transform.parent = pickUpper.gameObject.transform;
                pickObj.transform.localRotation = Quaternion.Euler(pickUpper.transform.localRotation.x, pickUpper.transform.localRotation.y, pickUpper.transform.localRotation.z);
            }
        }
        if (carrying)
            if (Input.GetKeyDown(KeyCode.C))
            {
                pickObj.GetComponent<PushObject>().dropped = true;
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
        if ((horizontalVal < 0 && facingRight) || (horizontalVal > 0 && !facingRight))
        {
            facingRight = !facingRight;
            charSprite.transform.Rotate(new Vector3(0, 180, 0));
        }
        float face;
        float forwardVal = Input.GetAxis("Vertical");
        if (forwardVal < 0 && facingforward)
        {
            face = 1;
            facingforward = !facingforward;
            float x = 0;
            float y = 0;
            float z = .1f;
            pickUpper.transform.localPosition = new Vector3(x, y, z * face);
            pickUpper.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (forwardVal > 0 && !facingforward)
        {
            face = -1;
            facingforward = !facingforward;
            float x = 0;
            float y = 0;
            float z = .1f;
            pickUpper.transform.localPosition = new Vector3(x, y, z * face);
            pickUpper.transform.Rotate(new Vector3(0, 180, 0));
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

        anim.SetFloat("horizontal", moveDirection.x);
        anim.SetFloat("vertical", moveDirection.z);
        Debug.Log(moveDirection.z);
        bool isIdle = moveDirection.z == 0 && moveDirection.x == 0;
        anim.SetBool("isMoving", !isIdle);

        //direction
        moveDirection *= speed;
        //gravity
        moveDirection.y += verticalSpeed;
        //movement
        charControl.Move(moveDirection * Time.deltaTime);
    }
}
