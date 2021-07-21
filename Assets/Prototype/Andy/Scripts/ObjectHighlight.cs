using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlight : MonoBehaviour
{
    private Material objMat;

	void Start()
	{
		//renderer = GetComponent<Renderer>();
		objMat = GetComponent<Renderer>().material;
	}

     private void OnMouseEnter()
    {
    	//renderer.material.color = Color.magenta;
    	objMat.color = Color.magenta;
    }

    private void OnMouseExit()
    {
    	//renderer.material.color = Color.white;
    	objMat.color = Color.grey;
    }
}
