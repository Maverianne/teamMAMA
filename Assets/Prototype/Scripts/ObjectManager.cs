using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public int numValue = 0;
    public GameObject[] worldTargets;
    public static ObjectManager instance;
    private void Awake()
    {
        instance = this; 
    }
    private void Update()
    {
        //giveOrder();

    }
    void giveOrder()
    {
        if (numValue < worldTargets.Length)
        {
           // worldTargets[numValue].GetComponent<TargetController>().myNumber = numValue;
            numValue++;
        }
    }
}
