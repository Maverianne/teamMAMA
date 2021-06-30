using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCharacter : MonoBehaviour
{
    public GameObject raycastObject;
    public GameObject pickUpTest;

    void Update()
    {
        PickUpObject();
    }

    void PickUpObject()
    {
        //if the player presses space bar
        if (Input.GetKeyDown("space"))
        {
            //it casts a forward facing ray from the characters current position
            CheckForHit();
            Debug.Log("You pressed to pick up an object");
        }
    }

    void CheckForHit()
    {
        RaycastHit objectHit;
        Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastObject.transform.position, fwd * 5, Color.green);
        if (Physics.Raycast(raycastObject.transform.position, fwd, out objectHit, 50))
        {
            //if the raycast hits a "pickup" object
            if (objectHit.transform.gameObject.tag == "PickUp")
            {
                //the item is collected
                Debug.Log("You bumpped into a pick up object");
                DestroyTheObject();
            }
        }
    }

    void DestroyTheObject()
    {
        Destroy(pickUpTest);
    }
}
