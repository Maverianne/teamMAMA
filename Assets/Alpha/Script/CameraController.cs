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

    [SerializeField]private AudioSource rotationClick;
    [SerializeField]private AudioSource rotatingSound;

    public bool pause;


    [Header("Change this parameter for the angle")]
    public float rotatingDegres;
    private void Start()
    {
        stopping = rotatingDegres;
       
    }

    private void Update()
    {
        if (GameManager.intance.pause == false && LevelDialogueManager.instance.talking == false) 
        {
            Controls();
        }
    }
    private void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !rotating && stopping != rotatingDegres * -1)
        {
            rotationClick.Play();
            targetAngle -= stopping;
            stopping = -rotatingDegres;
        }
        if (Input.GetKeyDown(KeyCode.E) && !rotating && stopping != rotatingDegres)
        {
            rotationClick.Play();
            targetAngle += stopping * -1;
            stopping = rotatingDegres;
        }
        if (targetAngle != 0)
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
