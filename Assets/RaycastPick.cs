using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastPick : MonoBehaviour
{
    public float rayDistance = 0.7f;
    public int orderValue = 0;
    int targetMask = 1 << 9;
    public static RaycastPick instance;
    public Vector3 moveDirection;
    public Camera camTarget;
    private void Awake()
    {
        instance = this; 
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.yellow);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = new Vector3(x, 0, z);
        if (moveDirection != Vector3.zero) transform.rotation = Quaternion.LookRotation(moveDirection);
    }
    void FixedUpdate()
    {
        ObjectPicking();
    }
    private void ObjectPicking()
    {
        if (Input.GetKeyDown("space"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, targetMask))
            {
                if (hit.collider.gameObject.GetComponent<TargetController>().myNumber == orderValue)
                {
                    hit.collider.gameObject.GetComponent<TargetController>().StartShake();
                    orderValue++;
                }
                else
                {
                    Debug.Log("that is wrong");
                }
            }
        }
    }
}
