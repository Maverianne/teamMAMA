using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public Animator anim;
    public bool canStart;
    public GameObject dialogue; 

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        canStart = false;
    }
    private void Update()
    {
        if (canStart)
        {
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("starting");
                dialogue.SetActive(true);
            }
        }
    }
    public void CanStartGame()
    {
        canStart = true;
    }
    public void DestroyAnim()
    {
        Destroy(gameObject);
    }
}
