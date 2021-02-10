using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : Projectile
{
    public AudioSource hitAudioSource;
    public AudioSource windAudioSource;

    public ParticleSystem hitParticleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GetComponent<PlagueHat>().enabled = true;
            hitAudioSource.Play();
            windAudioSource.Stop();
            hitParticleSystem.Play();
        }
    }
}
