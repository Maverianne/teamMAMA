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

    private AudioSource typing;

    public string text;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        typing = gameObject.GetComponent<AudioSource>();
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
            DialogueData("Player", "");   
        }
        else if (turn == 1 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Player", "");
        }  
        else if (turn == 2 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Player", "");
        }
        else if (turn == 3 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Ramon", "Player");
        }
        else if (turn == 4 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Ramon", "");
        }
        else if (turn == 5 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Player", "Ramon");
        }
        else if (turn == 6 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Player", "");
        }   
        else if (turn == 7 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Player", "");
        } 
        else if (turn == 8 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Sasha", "Player");
        }
        else if (turn == 9 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Player", "Sasha");
        }
        else if (turn == 10 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Player", "");
        }
        else if (turn == 11 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Sasha", "Player");
        }
        else if (turn == 12 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Sasha", "");
        } 
        else if (turn == 13 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Sasha", "");
        } 
        else if (turn == 14 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            DialogueData("Sasha", "");
        }
        else if (turn == 15 && Input.GetKeyDown(KeyCode.Space) && !talking)
        {
            StartCoroutine(Close(dialogueBox[2], 2));
            StartCoroutine(NewScene());
        }
    }
    private void DialogueData(string characterName, string previousCharacter)
    {
        talking = true;
        int i = turn;
        int c = 0;
        int b = 0;

        text = dialogue.Dialogue[i];
        if (characterName == "Player" )
        {
            c = 0;
        }
        else if (characterName == "Ramon")
        {
            c = 1;
        }
        else if (characterName == "Sasha")
        {
            c = 2;
        }
        anim[c].SetTrigger("talking");
        Open(dialogueBox[c], c);

        if (previousCharacter == "Player")
        {
            b = 0;
        }
        else if (previousCharacter == "Ramon")
        {
            b = 1;
        }
        else if (previousCharacter == "Sasha")
        {
            b = 2;
        }
        if (previousCharacter != "") {
            StartCoroutine(Close(dialogueBox[b], b));
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
            typing.Play();
            time += Time.deltaTime * writingSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textLabel.text = textToType.Substring(0, charIndex);
            yield return null;
        }
        textLabel.text = textToType;
        typing.Stop();
        talking = false;
        turn++;
    }
    private void Open(GameObject box, int c){
        
        box.SetActive(true);
        Run(text, textBox[c], 25);
    }
    private IEnumerator Close(GameObject box, int b)
    {
        dialogueAnim[b].SetTrigger("close");
        textBox[b].text = string.Empty;
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
        GameManager.intance.ChangeScene(1);
    }
}
