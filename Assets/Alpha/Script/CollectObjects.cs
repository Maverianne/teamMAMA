using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectObjects : MonoBehaviour
{
    public static CollectObjects instance;

    public int itemsToCollect, currentItems, collectClue;
    public GameObject setItems, inventoryUI, bubbleUI;
    public bool allItemsCollected, playerNear, showBubble;
    public TMPro.TextMeshProUGUI bubbleNumber, inventoryNumber;

    //forDialogue
    enum collection
    {
        MUSHROOM,
        FIRESTICKS
    }
    private collection myCollection;
    public int dialogueNumber;
    public string text;
    public string collectionType;


    private void Start()
    {
        inventoryUI.SetActive(false);
        bubbleUI.SetActive(false);
        switch (collectionType)
        {
            case "mushroom" :
                myCollection = collection.MUSHROOM;
                break;
            case "firesticks":
                myCollection = collection.FIRESTICKS;
                break; ;
        }
    }
    private void Update()
    {

        DialogueManager();
        if (showBubble)
        {
            BubbleActive();
        }
        if(playerNear && currentItems == 0)
        {
            dialogueNumber = 1;

        }
        else if (playerNear && currentItems < 5 && currentItems != 0)
        {
            dialogueNumber = 2;
        }
        if (Input.GetKeyDown("space") && playerNear && !allItemsCollected)
        {
            LevelDialogueManager.instance.DialoguePromt(text);
            LevelDialogueManager.instance.talking = true;
            Debug.Log("Dialogue");
            showBubble = true;
        }

        allItemsCollected = currentItems >= itemsToCollect;
        if (allItemsCollected && playerNear && Input.GetKeyDown("space") && showBubble/*&& CharacterController2D.instance.carrying == false*/) 
        {
            setItems.SetActive(true);
          //  PushObject.instance.canBeHome = true;
            bubbleUI.GetComponent<CollectionCounter>().Animation();
            StartCoroutine("CloseBubble");
        }
        else if (allItemsCollected && playerNear && Input.GetKeyDown("space") && !showBubble/*&& CharacterController2D.instance.carrying == false*/)
        {
            setItems.SetActive(true);
        }

            ActivateInventory();
    }
    private void DialogueManager()
    {
        if (myCollection == collection.MUSHROOM)
        {
            switch (dialogueNumber)
            {
                case 1:
                    text = "I should look for something to cook";
                    break;
                case 2:
                    text = "I need more";
                    break;
            }
        }
        if (myCollection == collection.FIRESTICKS)
        {
            switch (dialogueNumber)
            {
                case 1:
                    text = "I need something to start the fire";
                    break;
                case 2:
                    text = "I need more";
                    break;
            }
        }
    }
    private void BubbleActive()
    {
        bubbleUI.SetActive(true);
        bubbleNumber.SetText(currentItems + "/5");
        if (allItemsCollected == true)
        {
            bubbleNumber.SetText("5/5");
        }
    }
    private void ActivateInventory()
    {
        if (currentItems >= 1)
        {
            inventoryUI.SetActive(true);
            inventoryNumber.SetText(currentItems + "");
        }
        if (allItemsCollected)
        {
            inventoryNumber.SetText("5");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
    IEnumerator CloseBubble()
    {
        showBubble = false;
        yield return new WaitForSeconds(1f);
        bubbleUI = null;
        bubbleNumber = null;
    }
}
