using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    public float speed;
    Vector3 startPos;
    public Transform currentPos;

    float angle;
    float currentAngle;

    public Transform Target;
    public bool movingRight, movingLeft;

    private void Start()
    {
        
        //currentPos.rotation = transform.rotation;
        //startPos = currentPos.eulerAngles;
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * speed, Space.Self);
        }
    }
}
