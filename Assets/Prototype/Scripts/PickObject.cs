using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    Camera cam;
    public int orderValue = 0;

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
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
