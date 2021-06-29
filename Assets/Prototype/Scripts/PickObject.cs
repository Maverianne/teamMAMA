using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    Camera cam;
    public GameObject[] Worldtargets;
    public int numValue = 0;
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
                if (hit.collider.gameObject.tag == "target" && hit.collider.gameObject.GetComponent<ObjectOrderManager>().myNumber == orderValue)
                {
                    hit.collider.gameObject.SetActive(false) ;
                    orderValue++;
                }
                else
                {
                    Debug.Log("that is wrong");
                }
            }
        }
        giveOrder();
    }
    void giveOrder()
    {
        if (numValue < Worldtargets.Length)
        {
            Worldtargets[numValue].GetComponent<ObjectOrderManager>().myNumber = numValue;
            Debug.Log(Worldtargets[numValue]);
            Debug.Log(Worldtargets[numValue].GetComponent<ObjectOrderManager>().myNumber);
            numValue++;
        }


            //if( numValue < Worldtargets.Length)
            // {
            //     targets.Add(Worldtargets[numValue], numValue);
            //     Debug.Log(numValue);
            //     numValue++;
            //     Debug.Log(targets.Values);
            // }
    }
}
