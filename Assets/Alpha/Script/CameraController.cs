using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject targetObj;
    public float targetAngle = 0;
    public float rotationAmount = 10f;

    public bool rotating;
    public float stopping;

    public Vector3 newPos;
    public Vector3 currenPos;

    [Header("Change this parameter for the angle")]
    public float rotatingDegres;
    private void Start()
    {
        stopping = rotatingDegres;
        currenPos = transform.position;
       
    }

    private void Update()
    {
        if(LevelDialogueManager.instance.talking == false) { 
        if (Input.GetKeyDown(KeyCode.Q) && !rotating && stopping != rotatingDegres * -1)
        {
            targetAngle -= stopping;

            stopping = -rotatingDegres;
        }
        if (Input.GetKeyDown(KeyCode.E) && !rotating && stopping != rotatingDegres)
        {
            targetAngle += stopping * -1;

            stopping = rotatingDegres;
        }
        if(targetAngle != 0)
        {
            Rotate();
            rotating = true;
        }
        else
        {
            rotating = false;
        }
        }
    }
    private void Rotate()
    {
        float step = Time.deltaTime * 10;
        if (targetAngle > 0)
        {
            
            transform.RotateAround(targetObj.transform.position, Vector3.up,  Mathf.Round(-rotationAmount * step));
            //transform.position = Vector3.MoveTowards(transform.position, currenPos, Time.deltaTime * 1);
            targetAngle -= Mathf.Round(rotationAmount * step);
    
            if (targetAngle < 0)
                targetAngle = 0;

        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(targetObj.transform.position, Vector3.up, Mathf.Round(rotationAmount * step));
            targetAngle += Mathf.Round(rotationAmount * step);
            //transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * 10);


            if (targetAngle > 0)
                targetAngle = 0;
        }
    }
}
