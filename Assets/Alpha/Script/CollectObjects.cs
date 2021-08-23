using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectObjects : MonoBehaviour
{
    public static CollectObjects instance;


    [Header("Collection Parameters")]
    public int currentItems;
 
    private bool allItemsCollected;
    private bool playerNear;

    [Header("Firestick Bubble Counter UI")]
    public GameObject f_placedObjects;
    public int f_itemsToCollect;
    public GameObject f_bubbleUI;
    public TMPro.TextMeshProUGUI f_bubbleNumber;
    private bool showBubble;

    [Header("Pot Parameters")]
    public int p_itemsToCollect;
    public GameObject p_placedObjects;
    public GameObject p_bubbleUI;
    public TMPro.TextMeshProUGUI p_bubbleNumber;

    [Header("Mushroom Parameters")]
    public int m_itemsToCollect;
    public GameObject m_bubbleUI;
    public TMPro.TextMeshProUGUI m_bubbleNumber;

    [Header("Dialogue")]
    private string text;
    [SerializeField] private DialogueObjects dialogue;


    [Header("For Steps")]
    public int stepNumber;
    public bool locked;


    [SerializeField] private AudioSource success;
    private void Start()
    {
  
        f_bubbleUI.SetActive(false);
        m_bubbleUI.SetActive(false);
        p_bubbleUI.SetActive(false);

        p_placedObjects.SetActive(false);
        f_placedObjects.SetActive(false);

        success = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        StepManager();

    }
    private void StepManager()
    {
        if(stepNumber == 1)
        {
            FirestickStep();
        }
        else if (stepNumber == 2)
        {
            PotStep();
        }
        else if(stepNumber == 3)
        {
            MushroomsStep();
        }
    }
    private void FirestickStep()
    {
        //First time you walk up to the firepit to prompt collecting sticks
        text = dialogue.Dialogue[0];
        if (Input.GetKeyDown("space") && playerNear && !allItemsCollected && !locked)
        {
            LevelDialogueManager.instance.DialoguePromt(text);
            LevelDialogueManager.instance.talking = true;
            playerNear = false;
            showBubble = true;
        }
        if (showBubble)
        {
            f_bubbleUI.SetActive(true);
            f_bubbleNumber.SetText(currentItems + "/5");
            if (allItemsCollected == true)
            {
                f_bubbleNumber.SetText("5/5");
            }
        }
        allItemsCollected = currentItems >= f_itemsToCollect;
        if (allItemsCollected && playerNear && Input.GetKeyDown("space") && showBubble/*&& CharacterController2D.instance.carrying == false*/)
        {
            success.Play();
            f_placedObjects.SetActive(true);
            //  PushObject.instance.canBeHome = true;
            f_bubbleUI.GetComponent<CollectionCounter>().Animation();
            StartCoroutine("CloseFireBubble");
            playerNear = false;
            PuzzleStepManager.intance.steps++;
            currentItems = 0;
            stepNumber++;
        }
        else if (allItemsCollected && playerNear && Input.GetKeyDown("space") && !showBubble/*&& CharacterController2D.instance.carrying == false*/)
        {
            success.Play();
            f_placedObjects.SetActive(true);
            PuzzleStepManager.intance.steps++;
            currentItems = 0;
            playerNear = false;
            stepNumber++;
        }
    }
    private void PotStep()
    {
        if (Input.GetKeyDown("space") && playerNear && !allItemsCollected && !locked)
        {
            showBubble = true;
        }
        if (showBubble)
        {
            p_bubbleUI.SetActive(true);
            p_bubbleNumber.SetText(currentItems + "/1");
            if (allItemsCollected == true)
            {
                p_bubbleNumber.SetText("1/1");
            }
        }
        allItemsCollected = currentItems >= p_itemsToCollect;
        if (allItemsCollected && playerNear && Input.GetKeyDown("space") && showBubble/*&& CharacterController2D.instance.carrying == false*/)
        {
            success.Play();
            p_placedObjects.SetActive(true);
            playerNear = false;
            p_bubbleUI.GetComponent<CollectionCounter>().Animation();
            StartCoroutine("ClosePotBubble");
            PuzzleStepManager.intance.steps++;
            currentItems = 0;
            stepNumber++;
        }
        else if (allItemsCollected && playerNear && Input.GetKeyDown("space") && !showBubble/*&& CharacterController2D.instance.carrying == false*/)
        {
            success.Play();
            p_placedObjects.SetActive(true);
            PuzzleStepManager.intance.steps++;
            currentItems = 0;
            playerNear = false;
            stepNumber++;
        }
    }
    private void MushroomsStep()
    {
        if (Input.GetKeyDown("space") && playerNear && !allItemsCollected && !locked)
        {
            showBubble = true;
        }
        if (showBubble)
        {
            m_bubbleUI.SetActive(true);
            m_bubbleNumber.SetText(currentItems + "/5");
            if (allItemsCollected == true)
            {
                m_bubbleNumber.SetText("5/5");
            }
        }
        allItemsCollected = currentItems >= m_itemsToCollect;
        if (allItemsCollected && playerNear && Input.GetKeyDown("space") && showBubble/*&& CharacterController2D.instance.carrying == false*/)
        {
            success.Play();
            m_bubbleUI.GetComponent<CollectionCounter>().Animation();
            StartCoroutine("CloseMushroomBubble");
        }
        else if (allItemsCollected && playerNear && Input.GetKeyDown("space") && !showBubble/*&& CharacterController2D.instance.carrying == false*/)
        {
            success.Play();
            PuzzleStepManager.intance.steps++;
            currentItems = 0;
            stepNumber++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"  && LevelDialogueManager.instance.talking == false)
        {
            playerNear = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNear = false;
        }
    }
    IEnumerator CloseFireBubble()
    {
        showBubble = false;
        yield return new WaitForSeconds(1f);
        f_bubbleUI = null;
        f_bubbleNumber = null;
    }
    IEnumerator ClosePotBubble()
    {
        showBubble = false;
        yield return new WaitForSeconds(1f);
        p_bubbleUI = null;
        p_bubbleNumber = null;
    }
    IEnumerator CloseMushroomBubble()
    {
        showBubble = false;
        yield return new WaitForSeconds(1f);
        m_bubbleUI = null;
        m_bubbleNumber = null;
    }
}
