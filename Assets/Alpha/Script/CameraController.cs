using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject targetObj;
    private float targetAngle = 0;
    const float rotationAmount = 2f;

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
        if (targetAngle > 0)
        {
            transform.RotateAround(targetObj.transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(targetObj.transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }
    }
}
