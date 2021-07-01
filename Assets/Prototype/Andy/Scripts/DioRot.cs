using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioRot : MonoBehaviour
{
	public int LeftRot;
	
	public int RightRot;

	public GameObject rotatedObject;
    

    public void LeftTurn()
    {
    	LeftRot += 90;
    	rotatedObject.transform.rotation = Quaternion.Euler(0,LeftRot,0);
    }

    public void RightTurn()
    {
    	RightRot += -90;
    	rotatedObject.transform.rotation = Quaternion.Euler(0,RightRot,0);
    }
}
