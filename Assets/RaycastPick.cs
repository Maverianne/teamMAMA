using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPick : MonoBehaviour
{
    public float rayDistance = 50;
    public int orderValue = 0;
    int targetMask = 1 << 8;


    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
    }
    void FixedUpdate()
    {
        ObjectPicking();
    }

    private void ObjectPicking()
    {
        if (Input.GetKeyDown("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, targetMask))
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
