using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public bool canPick;
    public GameObject myParent;
    private bool locked;
    [SerializeField] private int myStep;
    public float shaking;
    private string lockedDialogue;
    [SerializeField] private DialogueObjects dialogue;



    private void Update()
    {
        if(myStep == myParent.GetComponent<CollectObjects>().stepNumber)
        {
            locked = false;
        }
        else if (myStep != myParent.GetComponent<CollectObjects>().stepNumber)
        {
            locked = true;
        }

        if(myStep == 1)
        {
            shaking = .5f;
        }
        else if (myStep == 2)
        {
            //if the pot is locked
            shaking = .2f;
            lockedDialogue = dialogue.Dialogue[0];
        }

        else if (myStep == 3)
        {
            //if the mushrooms are locked
            shaking = .3f;
            lockedDialogue = dialogue.Dialogue[1]; ;
        }
    }
    public void Picked()
    {
        if (locked)
        {
            LockedAndPicked();
        }
        else
        {
            StartShake();
        }
    }
    private void LockedAndPicked()
    {
        LevelDialogueManager.instance.DialoguePromt(lockedDialogue);
        LevelDialogueManager.instance.talking = true;
    }
    public void StartShake()
    {
        myParent.GetComponent<CollectObjects>().currentItems++;
        StartCoroutine(Shake(.5f, shaking));
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        CharacterController2D.instance.collectItem = false;
        Vector3 startPos = transform.localPosition;
        float elapsed = 0.0f;
         while(elapsed < duration)
        {
            canPick = false;
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * magnitude);

            transform.localPosition = new Vector3(newPos.x, startPos.y, startPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = startPos;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canPick = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canPick = false;
        }
    }
}
