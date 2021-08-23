using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuDialogueManager : MonoBehaviour
{

    public static MainMenuDialogueManager instance;
    public TextMeshProUGUI[] textBox;
    public GameObject[] dialogueBox;
    public int turn = 0;
    public bool talking;
    public Animator[] anim;
    public Animator[] dialogueAnim;
    [SerializeField] private DialogueObjects dialogue;


    public bool dialogueTime;
    public bool coroutine;

    public string text;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        int array = dialogueBox.Length;
        dialogueAnim = new Animator[array];

        for (int i = 0; i < dialogueAnim.Length; i++)
        {
            dialogueAnim[i] = dialogueBox[i].GetComponent<Animator>();
        }
        foreach (GameObject box in dialogueBox)
        {
            box.SetActive(false);
        }
    }

    private void Update()
    {
        if (MainMenuStart.intance.startDialogue == true && !coroutine)
        {
            StartCoroutine(StartDialogue());
        }
        if (dialogueTime)
            DialogueTurn();
  
    }

    private void DialogueTurn()
    {
        if (turn == 0 && !talking)
        {
            DialogueData();
        }
        else if (turn == 1 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData();
        }
        else if (turn == 2 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData();
        }
        else if (turn == 3 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            StartCoroutine(Close(dialogueBox[turn - 1]));
            StartCoroutine(NewScene());

        }
    }
    private void DialogueData()
    {
        talking = true;
        int i = turn;
        text = dialogue.Dialogue[i];
        anim[i].SetTrigger("talking");
        Open(dialogueBox[i]);
        if(i != 0) {
            StartCoroutine(Close(dialogueBox[i-1]));
        }
        else
        {
            Debug.Log("there is nothing to close");
        }
    }

    public void Run(string textToType, TMP_Text textLabel, float writingSpeed)
    {
        StartCoroutine(TypeText(textToType, textLabel, writingSpeed));
    }
    private IEnumerator TypeText(string textToType, TMP_Text textLabel, float writingSpeed)
    {
        textLabel.text = string.Empty;
        yield return new WaitForSeconds(.2f);
        float time = 0;
        int charIndex = 0;
        while (charIndex < textToType.Length)
        {
            time += Time.deltaTime * writingSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);
            yield return null;
        }
        textLabel.text = textToType;
        talking = false;
        turn++;
    }
    private void Open(GameObject box){
        
        box.SetActive(true);
        Run(text, textBox[turn], 25);
    }
    private IEnumerator Close(GameObject box)
    {
        dialogueAnim[turn - 1].SetTrigger("close");
        textBox[turn - 1].text = string.Empty;
        yield return new WaitForSeconds(.5f);
        box.SetActive(false);
    }
    public IEnumerator StartDialogue()
    {
        coroutine = false;
        yield return new WaitForSeconds(.5f);
        dialogueTime = true;
    }

    private IEnumerator NewScene()
    {
        yield return new WaitForSeconds(.5f);
        GameManager.intance.NPCOne(1);
    }
}
