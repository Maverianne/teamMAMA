using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem LeafParticles = null;
    [SerializeField] ParticleSystem LeafParticles2 = null;

    [SerializeField] private bool playerNear;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerNear)
        {
            PlayParticle();
          
        }
    }

    public void PlayParticle()
    {
        LeafParticles.Play();
        LeafParticles2.Play();
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
}
