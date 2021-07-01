using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicked : MonoBehaviour
{
	//public float force = 5;
	//or if we add a vector
	public Vector3 shoot = new Vector3(5,20,0);


    // Update is called once per frame
    private void Update()
    {
    	
    	//here we'll activate this code only when the mouse is cliked
    	if(Input.GetMouseButtonDown(0))
    	{

    		//Here we'll use our raycasts from the direction of the camera
    		RaycastHit hit; //for now we won't use this ray

    		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    		//here we're sending information into a variable without returning it (ray, out hit)
    		//so now ray will store info from whatever the ray is hitting
    		//the third value is the distance of the ray before it stops
    		if (Physics.Raycast(ray, out hit, 500.0f))
    		{
    			//now with this internal if, we check if the hit exists
    			if (hit.transform != null)
    			{
    				//if it does, we call out this function
    				
    				Rigidbody RB;

    				if (RB = hit.transform.GetComponent<Rigidbody>())
    				{
    					PrintName(hit.transform.gameObject);
    					MoveInteractable(RB);

    				}


    			}
    		}

    	}
        
    }

    private void PrintName (GameObject interactable)
    { //here we are making a function that will use a GameObject to work

        //this will print the name of our gameobject
        print(interactable.name);
    }

    private void MoveInteractable (Rigidbody rb)
    {
    	//rb.AddForce(rb.transform.up * force, ForceMode.Impulse);
    	rb.AddForce(shoot, ForceMode.Impulse);
    	//yay! it works with a vector!!

    }

   


}
