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

    public Transform camTrans;
    public Vector3 camForward;

    private void Awake()
    {
        instance = this; 
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance, Color.yellow);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        camTrans = camTarget.transform;
        camForward = camTrans.transform.forward;
        camForward.y = 0;
        camForward = camForward.normalized;

        moveDirection = (x * camTrans.right + z * camForward).normalized;
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
                hit.collider.gameObject.GetComponent<TargetController>().StartShake();
                orderValue++;
            }
        }
    }
}
