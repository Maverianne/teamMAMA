using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjects : MonoBehaviour
{
    public bool playerClose;

    public GameObject myObject;

    public bool pickedObject;
    public string nameObject;

    private void Start()
    {
        playerClose = false;
        pickedObject = false;
    }
    public void Update()
    {
        switch (nameObject)
        {
            case "Bridge":
                pickedObject = LevelOnePuzzle.instance.pickedPlank;
                break;
            case "Nest":
                pickedObject = LevelOnePuzzle.instance.pickedNest;
                break;
        }

        if (playerClose && Input.GetKeyDown("space") && pickedObject)
        {
            myObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerClose = true;
        }
    }
}
