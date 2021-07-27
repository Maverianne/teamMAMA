using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public static PushObject instance; 
    public bool available, dropped, canBeHome, noDrop;
    public float offsetY, offsetX, offsetZ;
    public Rigidbody rb;
    public RigidbodyConstraints rbOgi;
    public float gravity;
    public float ground;
    public GameObject home;
    public Vector3 homeTrans;
    public GameObject fire;

    public float speed = 2f; 

    private void Awake()
    {
        instance = this;         
    }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
        rbOgi = rb.constraints;
    }
    private void FixedUpdate()
    {
        Carried();
    }
    private void Update()
    {
        if (canBeHome && home.GetComponent<PickTarget>().playerNear == true && CharacterController2D.instance.carrying == true)
            noDrop = true;
        else
            noDrop = false;
        if (canBeHome && home.GetComponent<PickTarget>().playerNear == true && Input.GetKeyDown("space"))
            PlacedHome();
    }
    public void Carried()
    {
        if (transform.parent != null)
        {
            rb.useGravity = false;
            transform.position = new Vector3 (transform.parent.position.x + offsetX, transform.parent.position.y + offsetY, transform.parent.position.z + offsetZ);
            CharacterController2D.instance.pickObj = gameObject;

        }
        if (dropped)
        {
            StartCoroutine("Gravity");
            CharacterController2D.instance.carrying = false;
            transform.parent = null;
        }
    }
    public void PlacedHome()
    {
        float step = speed * Time.deltaTime;
        transform.parent = home.gameObject.transform;
        transform.position = new Vector3(0f, 0f, 0f); 
        //homeTrans = new Vector3(0f,0f,0f);
        //transform.position = Vector3.MoveTowards(transform.position, homeTrans, step);
    }
    IEnumerator Gravity()
    {
        rb.useGravity = true;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        yield return new WaitForSeconds(2f);
        rb.useGravity = false;
        rb.constraints = rbOgi;
        dropped = false;
    }
}
