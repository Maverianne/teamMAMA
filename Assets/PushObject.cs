using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public bool available, dropped;
    public float offset;
    public Rigidbody rb;
    public RigidbodyConstraints rbOgi;
    public float gravity;
    public float ground;
    public GameObject home;
    public Transform homeTrans;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
        rbOgi = rb.constraints;
    }
    private void FixedUpdate()
    {
        Carried();
    }
    public void Carried()
    {
        if (transform.parent != null)
        {
            rb.useGravity = false;
            //rb.constraints = RigidbodyConstraints.None;
            transform.position = transform.parent.position;
      
        }
        if (dropped)
        {
            StartCoroutine("Gravity");
        }
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
