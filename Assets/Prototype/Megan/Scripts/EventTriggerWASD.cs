using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerWASD : MonoBehaviour
{
    public GameObject nestPickUp;
    public GameObject woodPickUp;
    public GameObject bridgeFix;
    public GameObject nestPlace;

    public bool nestPicked, woodPicked, bridgeFixed, NestPlaced;

    public float rayDistance = 50;
    public int orderValue = 0;

    void Update()
    {
        isPickedUp();
    }

    void Start()
    {
        nestPicked = false;
        woodPicked = false;
        bridgeFixed = false;
        NestPlaced = false;
    }

    void isPickedUp()
    {
        if (Input.GetKeyDown("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
            {
                Debug.Log("this is happening");
                if (hit.collider.gameObject.name == "Nest")
                {
                    Debug.Log("You picked up the nest");
                    nestPicked = true;
                }
                if (hit.collider.gameObject.name == "Wood" && nestPicked == true)
                {
                    woodPicked = true;
                }
                if (hit.collider.gameObject.name == "Bridge" && nestPicked == true && woodPicked == true)
                {
                    Debug.Log("The bridge is fixed");
                    bridgeFix.gameObject.SetActive(true);
                }
            }
        }
    }
}
