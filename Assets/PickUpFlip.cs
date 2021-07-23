using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlip : MonoBehaviour
{
    public bool facingforward;
    public Transform forward;
    public void Start()
    {
       // forward.position = new Vector3 (0f, 0f, -0.1f);
    }
    private void Update()
    {
        //Flip();    
    }
    public void Flip()
    {
        float face;
        float forwardVal = Input.GetAxis("Vertical");
        if (forwardVal > 0 && facingforward)
        {
            face = -1;
            facingforward = !facingforward;
            float x = 0;
            float y = 0;
            float z = .2f;
            transform.localPosition = new Vector3 (x,y, z * face);
            transform.Rotate(new Vector3(0, 180, 0));
        }
        else if  (forwardVal < 0 && !facingforward)
        {
            face = 1;
            facingforward = !facingforward;
            float x = 0;
            float y = 0;
            float z = .08f;
            transform.localPosition = new Vector3(x, y, z * face);
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
