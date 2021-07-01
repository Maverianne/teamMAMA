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


        //if (movingRight)
        //{
        //    if (Mathf.Round(transform.eulerAngles.y) == currentAngle || Mathf.Round(transform.eulerAngles.y) <= angle + 90 )
        //    {
        //        transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
        //        currentAngle = angle;
        //    }
        //    else if (Mathf.Round(transform.eulerAngles.y) == 90 || Mathf.Round(transform.eulerAngles.y) <= angle + 90)
        //    {
        //        transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
        //        currentAngle = angle;
        //    }

        //    else if (Mathf.Round(transform.eulerAngles.y) == 180 || Mathf.Round(transform.eulerAngles.y) <= angle + 90)
        //    {
        //        transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
        //    }
        //    else if (Mathf.Round(transform.eulerAngles.y) == 270 || Mathf.Round(transform.eulerAngles.y) <= angle + 90)
        //    {
        //        transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.Self);
        //    }
        //}
        //if(!movingRight && !movingLeft)
        //{
        //    currentPos.rotation = transform.rotation;
        //}
        //transform.Rotate(new Vector3(0, 1, 0));
        //transform.Rotate(new Vector3(0, 0, 1));

        //and if (Mathf.Round(transform.eulerAngles.z) == 180) { transform.Rotate(new Vector3(0, 0, -180)); }
    }
}
