using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    private AudioSource step;


    private void Start()
    {
        step = gameObject.GetComponent<AudioSource>();
    }

    public void StepPlay()
    {
        step.Play();
    }
}
