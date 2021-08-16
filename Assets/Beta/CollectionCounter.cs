using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCounter : MonoBehaviour
{
    public Camera camTarget;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        Vector3 targetVector = camTarget.transform.position - transform.position;
        float newYAngle = Mathf.Atan2(targetVector.x, targetVector.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, newYAngle, 0);
    }
    public void Animation()
    {
        anim.SetTrigger("completed");
    }
    public void IdleAnimation()
    {
        anim.SetTrigger("idle");
    }
    public void DeactivateBubble()
    {
        gameObject.SetActive(false);
    }
}
