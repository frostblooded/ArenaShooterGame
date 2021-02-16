using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : Projectile
{
    public AudioSource hitAudioSource;
    public AudioSource windAudioSource;

    public ParticleSystem hitParticleSystem;

    Animator animator;
    PlagueHat plagueHat;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        plagueHat = GetComponent<PlagueHat>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetBool("open", true);
            plagueHat.enabled = true;
            hitAudioSource.Play();
            windAudioSource.Stop();
            hitParticleSystem.Play();
        }
    }
}
