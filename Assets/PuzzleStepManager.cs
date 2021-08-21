using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStepManager : MonoBehaviour
{
    public static PuzzleStepManager intance;
    public int steps = 1;
    public string text;
    public bool step1, step2, step3;

    public void Awake()
    {
        intance = this; 
    }
    private void Start()
    { 
        //Opening scene 
        text = "After hiking for so long, I got really hungry.";
        StartCoroutine(Dialogue());
    }
    public void Update()
    {
        if(steps == 2 && !step1)
        {
            //after you add the fire sticks
            text = "I then remembered the mushroom soup my g'ma used to make.";
            StartCoroutine("Dialogue");
            step1 = true;
        }
        if (steps == 3 && !step2)
        {
            //once you put down the pot
            text = "The hardest part was just finding the mushrooms...";
            StartCoroutine("Dialogue");
            step2 = true;
        }
        if (steps == 4 && !step3)
        {
            //the finale text!
            text = "But the soup actually turned out well! I'm... actually really proud...";
            StartCoroutine("LastDialogue");

            step3 = true;
        }
    }
    IEnumerator Dialogue()
    {
        CharacterController2D.instance.speed = 0;
        CharacterController2D.instance.anim.SetBool("isMoving", false);
        yield return new WaitForSeconds(.5f);
        LevelDialogueManager.instance.DialoguePromt(text);
        LevelDialogueManager.instance.talking = true;

    }
    IEnumerator LastDialogue()
    {
        CharacterController2D.instance.speed = 0;
        CharacterController2D.instance.anim.SetBool("isMoving", false);
        yield return new WaitForSeconds(.5f);
        LevelDialogueManager.instance.DialoguePromt(text);
        LevelDialogueManager.instance.talking = true;
        LevelDialogueManager.instance.bye = true;
    }
}
