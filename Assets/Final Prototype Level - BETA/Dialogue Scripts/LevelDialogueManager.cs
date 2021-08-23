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
    private AudioSource typing;

    [SerializeField]private float writingSpeed = 50f;

    private void Awake()
    {
        instance = this;
        speed = CharacterController2D.instance.speed;
    }
    private void Start()
    {
        typing = gameObject.GetComponent<AudioSource>();
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
        }
        else if (!talking)
        {
            CharacterController2D.instance.speed = speed;
            endDialogue = false;
            dialogueUI.SetActive(false);
        }
        if (endDialogue && Input.GetKeyDown("space") && !bye)
        {
            talking = false;
            dialogueUI.SetActive(false);
            endDialogue = false;
        }

    }
    public void DialoguePromt(string textToType)
    {
        talking = true;
        StartCoroutine(TypeText(textToType, dialogueText));
    }
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        dialogueText.text = string.Empty;

        yield return new WaitForSeconds(.2f);
        float time = 0;
        int charIndex = 0;
        while (charIndex < textToType.Length)
        {
            typing.Play();
            time += Time.deltaTime * writingSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            dialogueText.text = textToType.Substring(0, charIndex);
            yield return null;
        }
        dialogueText.text = textToType;
        typing.Stop();
        endDialogue = true;
    }
}
