using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTriggers1 : MonoBehaviour
{
	//this is for the Level cleared ending

    public GameObject dialogue1;
    public GameObject dialogue2;

    public GameObject button1;
    public GameObject button2;

    void OnTriggerEnter(Collider col)
    {
    	if (col.gameObject.tag == "Player")
    	{
    		dialogue1.SetActive(false);
    		button1.SetActive(false);
    		button2.SetActive(false);
    		dialogue2.SetActive(true);	
    	}
    	

    }
}
