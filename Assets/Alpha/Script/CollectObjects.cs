using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectObjects : MonoBehaviour
{
    public int itemsToCollect;
    public int currentItems;
    public static CollectObjects instance;
    public GameObject setItems;
    public bool allItemsCollected, playerPlacing;
    public TMPro.TextMeshProUGUI score;
    private void Awake()
    {
        instance = this; 
    }
    private void Update()
    {
        score.SetText(currentItems + "/5");
        allItemsCollected = currentItems >= itemsToCollect;
        if (allItemsCollected && playerPlacing == true && Input.GetKeyDown("space") && CharacterController2D.instance.carrying == false) 
        {
            setItems.SetActive(true);
            PushObject.instance.canBeHome = true;

        }
        if(allItemsCollected == true)
        {
            score.SetText("5/5");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPlacing = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPlacing = false;
        }
    }
}
