using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDialogueManager : MonoBehaviour
{
    public static LevelDialogueManager instance;
    public bool talking, endDialogue;
    public float speed;
    public GameObject dialogueUI;
    public TMPro.TextMeshProUGUI dialogueText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        speed = CharacterController2D.instance.speed;
        talking = false;
    }

    public void Update()
    {
        if (talking)
        {
            CharacterController2D.instance.speed = 0;
            CharacterController2D.instance.anim.SetBool("isMoving", false);
            dialogueUI.SetActive(true);
            StartCoroutine("EndDialogue");
   
        }
        else if (!talking)
        {
            CharacterController2D.instance.speed = speed;
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
        yield return new WaitForSeconds(1);
        endDialogue = true;
    }
}
