using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : Projectile
{
    public AudioSource hitAudioSource;
    public ParticleSystem hitParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            hitAudioSource.Play();
            hitParticleSystem.Play();
            GetComponent<PlagueHat>().enabled = true;
            Destroy(GetComponent<AudioSource>());
            Destroy(this);
            enabled = false;
        }
    }
}
