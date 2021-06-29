using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPick : MonoBehaviour
{
    public float rayDistance;
    public int orderValue = 0;
    int layerMask = 1 << 8;


    private void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawLine(transform.position, fwd, Color.yellow);
    }
    void FixedUpdate()
    {
        ObjectPicking();
    }

    private void ObjectPicking()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("spacing");
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, fwd, out hit, rayDistance, layerMask))
            {

                if (hit.collider.gameObject.tag == "target" && hit.collider.gameObject.GetComponent<TargetController>().myNumber == orderValue)
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
