using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public static MainMenuStart intance;
    public Animator anim;
    public bool canStart;
    public GameObject dialogue;

    public bool startDialogue;

    private void Awake()
    {
        intance = this;        
    }
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
        startDialogue = true;
        Destroy(gameObject);
    }

}
