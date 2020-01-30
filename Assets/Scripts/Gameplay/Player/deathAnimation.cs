using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathAnimation : MonoBehaviour
{
    public ParticleSystem effect;
    public AudioSource playerDeath;

    private void Start()
    {
        playerDeath = GetComponent<AudioSource>();
        effect = GetComponent<ParticleSystem>();
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            effect.Play();
            playerDeath.Play();
        }
    }
}
