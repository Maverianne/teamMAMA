using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    public int itemsToCollect;
    public int currentItems;
    public static CollectObjects instance;
    public GameObject setItems;
    public bool allItemsCollected, playerPlacing;
    private void Awake()
    {
        instance = this; 
    }
    private void Update()
    {
        allItemsCollected = currentItems >= itemsToCollect;
        if (allItemsCollected && playerPlacing == true && Input.GetKeyDown("space"))
        {
            setItems.SetActive(true);
            PushObject.instance.canBeHome = true;

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
