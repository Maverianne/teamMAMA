using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSign : MonoBehaviour
{
    [SerializeField]private DialogueObjects dialogue;
    private bool reading = false;


    private void Update()
    {
        if(reading && Input.GetKeyDown(KeyCode.Space))
        {
            LevelDialogueManager.instance.DialoguePromt(dialogue.Dialogue[0]);
            reading = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            reading = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            reading = false;
        }
    }

}
