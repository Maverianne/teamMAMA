using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastPick : MonoBehaviour
{
    public float rayDistance = 0.7f;
    public int orderValue = 0;
    int targetMask = 1 << 9;
    public static RaycastPick instance;
    private void Awake()
    {
        instance = this; 
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.yellow);
        //ObjectHighlight();
    }
    void FixedUpdate()
    {
        ObjectPicking();
    }
    private void ObjectHighlight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, targetMask))
        {
            if (hit.collider.gameObject.GetComponent<TargetController>().myNumber == orderValue && hit.collider.gameObject != null)
            {
                hit.collider.gameObject.GetComponent<TargetController>().highlighted = true;
            }
            else if (hit.collider.gameObject == null)
            {
                hit.collider.gameObject.GetComponent<TargetController>().highlighted = false;
            }
        }
    }
    private void ObjectPicking()
    {
        if (Input.GetKeyDown("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, targetMask))
            {
                if (hit.collider.gameObject.GetComponent<TargetController>().myNumber == orderValue)
                {
                    hit.collider.gameObject.GetComponent<TargetController>().StartShake();
                    orderValue++;
                }
                else
                {
                    Debug.Log("that is wrong");
                }
            }
        }
    }
}
