using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public static PushObject instance; 
    public bool available, dropped, canBeHome, noDrop, near;
    public float offsetY, offsetX, offsetZ;
    public Rigidbody rb;
    public RigidbodyConstraints rbOgi;
    public GameObject home;
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
    private void Update()
    {
        Carried();
     
        if (canBeHome && near)
            noDrop = true;
        else
            noDrop = false;


    }
    public void Carried()
    {
        if (transform.parent != null)
        {
            rb.useGravity = false;
            transform.position = new Vector3 (transform.parent.position.x + offsetX, transform.parent.position.y + offsetY, transform.parent.position.z + offsetZ);
            CharacterController2D.instance.pickObj = gameObject;

        }
        if (!noDrop && dropped)
        {
            StartCoroutine("Gravity");
            CharacterController2D.instance.carrying = false;
            transform.parent = null;
        }
    }
    public void PlacedHome()
    {
        offsetZ = 0;
        noDrop = true;
        near = true;
        dropped = false;
        available = false;
        transform.parent = home.gameObject.transform;
        transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y , transform.parent.position.z - offsetZ);
        fire.SetActive(true);
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "home")
        {
            near = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "home")
        {
            near = false;
        }
    }
}
