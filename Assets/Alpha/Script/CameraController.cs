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
    public float stopping = 70f;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && !rotating && stopping != -70f)
        {
            targetAngle -= 70f;
            stopping = -70f;
        }
        if (Input.GetKeyDown(KeyCode.E) && !rotating && stopping != 70f)
        {
            targetAngle += 70f;
            stopping = 70f;
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

    private void Rotate()
    {
        float step = Time.deltaTime * 10;
        if (targetAngle > 0)
        {
            
            transform.RotateAround(targetObj.transform.position, Vector3.up,  Mathf.Round(-rotationAmount * step));
            targetAngle -= Mathf.Round(rotationAmount * step);
            if (targetAngle < 0)
                targetAngle = 0;

        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(targetObj.transform.position, Vector3.up, Mathf.Round(rotationAmount * step));
            targetAngle += Mathf.Round(rotationAmount * step);

            if (targetAngle > 0)
                targetAngle = 0;
        }
    }
}
