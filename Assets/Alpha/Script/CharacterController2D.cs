using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public static CharacterController2D instance;

    [Header("Movement")]
        public Camera camTarget;
        public Vector3 camForward;
        public CharacterController charControl;
        public Transform camTrans;
        public Vector3 moveDirection;
        public float speed;

    [Header("Gravity")]
        public float gravity;
        private float verticalSpeed;

    [Header("Flip the Character")]
        public bool facingRight;
        public bool facingforward;
        public GameObject charSprite;

    [Header("Picking and Dropping")]
        public bool carrying;
        public GameObject pickObj;
        public GameObject pickUpper;
        private bool pickUp;

    [Header("For Collecting")]
        public bool collectItem;
        public GameObject collect;

    [Header("For Animation")]
        public Animator anim;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anim = charSprite.GetComponent<Animator>();
        anim.SetBool("facingFront", true);
    }
    private void Update()
    {
        Movement();
        Rotate();
 
        PickingObject();
        if(speed != 0) { 
            Animations();
            Flip();
        }
        if (Input.GetKeyDown("space") && collectItem == true && LevelDialogueManager.instance.talking == false)
        {
            collect.gameObject.GetComponent<TargetController>().Picked();
            collectItem = false;
        }
        if(!collectItem)
        {
            collect = null;
        }

    }
    private void PickingObject()
    {
        if (pickUp && pickObj.GetComponent<PushObject>().available)
        {
            if (Input.GetKeyDown("space"))
            {
                StartCoroutine("CarryingSomething");
                pickObj.transform.parent = pickUpper.gameObject.transform;
                pickObj.transform.localRotation = Quaternion.Euler(pickUpper.transform.localRotation.x, pickUpper.transform.localRotation.y, pickUpper.transform.localRotation.z);
            }
        }
        if (carrying && pickObj.GetComponent<PushObject>().noDrop == false)
        {
            speed = 1.5f;
            if (Input.GetKeyDown("space"))
            {
                pickObj.GetComponent<PushObject>().dropped = true;
                carrying = false;
            }
        }
        else if (carrying && pickObj.GetComponent<PushObject>().noDrop == true)
        {
            if (Input.GetKeyDown("space"))
            {
                pickObj.GetComponent<PushObject>().PlacedHome();
                carrying = false;
                speed = 2f;
            }
        }
        else if (carrying)
        {
            speed = 2f;
        }
    }
    IEnumerator CarryingSomething()
    {
        yield return new WaitForSeconds(.5f);
        carrying = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pushableObject" && !carrying)
        {
            pickObj = other.gameObject;
            pickUp = true;
        }
        if(other.tag == "collectable" && !carrying && !pickUp) 
        {
            collectItem = true;
            collect = other.gameObject;
        }
        if (other.tag == "home" && carrying)
        {
            pickObj.GetComponent<PushObject>().near = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pushableObject" && !carrying)
        {
            pickObj = null;
            pickUp = false;
        }
        if (other.tag == "collectable")
        {
            collectItem = false;
            collect = null;
        }
        if (other.tag == "home" && carrying)
        {
            pickObj.GetComponent<PushObject>().near = false;
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

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

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
    private void Animations()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        if (x != 0 || z != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        } 
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("facingFront", false);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("facingFront", true);
        }

    }
}
