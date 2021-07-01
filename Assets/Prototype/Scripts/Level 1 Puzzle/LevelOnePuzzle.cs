using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnePuzzle : MonoBehaviour
{
    public GameObject nest, woodPlank;
    public bool pickedNest, pickedPlank;
    public static LevelOnePuzzle instance;

    private void Awake()
    {
        instance = this; 
    }
    private void Start()
    {
        pickedNest = false;
        pickedPlank = false;
    }
    private void Update()
    {
        if(RaycastPick.instance.orderValue == 0)
        {
            pickedNest = false;
            pickedPlank = false;
        }
        if (RaycastPick.instance.orderValue == 1)
        {
            pickedNest = true;
            pickedPlank = false;
        }
        if (RaycastPick.instance.orderValue == 2)
        {
            pickedNest = true;
            pickedPlank = true;
        }
    }
}