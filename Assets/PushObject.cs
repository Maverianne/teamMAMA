using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public bool available;
    public float offset;
    public Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        Carried();
    }
    public void Carried()
    {
        if(transform.parent != null)
        {
            rb.useGravity = false;
            transform.position = new Vector3(transform.parent.position.x - 0.2f, transform.parent.position.y + offset, transform.parent.position.z);
            Debug.Log("I'm being held");
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = true;
            StartCoroutine("Gravity");
        }
    }
    IEnumerator Gravity()
    {
        yield return new WaitForSeconds(1f);
        rb.useGravity = true;
        rb.isKinematic = true;
    }
}
