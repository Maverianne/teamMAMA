using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDialogueManager : MonoBehaviour
{
    public static LevelDialogueManager instance;
    public bool talking = false;
    public bool bye = false;
    public bool endDialogue;
    public float speed;
    public GameObject dialogueUI;
    public TMPro.TextMeshProUGUI dialogueText;
    private void Awake()
    {
        instance = this;
        speed = CharacterController2D.instance.speed;
    }
    public void Update()
    {
        if (talking)
        {
            CharacterController2D.instance.speed = 0;
            CharacterController2D.instance.anim.SetBool("isMoving", false);
            dialogueUI.SetActive(true);
            if (bye)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dialogueUI.SetActive(false);
                
                    GameManager.intance.Credits();
                    bye = false;
                    talking = false;
                }
            }
            else { StartCoroutine("EndDialogue"); }
           
   
        }
        else if (!talking)
        {
            CharacterController2D.instance.speed = speed;
            endDialogue = false;
            dialogueUI.SetActive(false);
        }
        if (endDialogue && Input.GetKeyDown("space"))
        {
            talking = false;
            dialogueUI.SetActive(false);
            endDialogue = false;
        }

    }
    public void DialoguePromt(string textUI = "")
    {
        talking = true;
        dialogueText.SetText(textUI);
    }
    public IEnumerator EndDialogue()
    {
        yield return new WaitForSeconds(0.5F);
        endDialogue = true;
    }
}
