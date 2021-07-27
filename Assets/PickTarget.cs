using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTarget : MonoBehaviour
{
    public bool playerNear;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNear = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNear = false;
        }
    }
}
