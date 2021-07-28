using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject targetObj;
    private float targetAngle = 0;
    const float rotationAmount = 1f;

    public bool rotating;

    private void Update()
    {
        //transform.LookAt(target);

        if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        {
            targetAngle -= 90f;
        }
        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            targetAngle += 90f;
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
