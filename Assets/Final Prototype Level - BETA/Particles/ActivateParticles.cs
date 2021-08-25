using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem LeafParticles = null;
    [SerializeField] ParticleSystem LeafParticles2 = null;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayParticle();
        }
    }

    public void PlayParticle()
    {
        LeafParticles.Play();
        LeafParticles2.Play();
    }
}
