using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 25;
    public float rotationSpeed = 200;

    public float initalForceMultiplier = 20;

    public AudioSource hitAudioSource;
    public AudioSource windAudioSource;

    public ParticleSystem hitParticleSystem;
    public Hat hat;

    [HideInInspector]
    public Vector3 direction;

    private void Start()
    {
        direction.Normalize();

        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(direction * initalForceMultiplier, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            hat.enabled = true;

            if(hitAudioSource)
            {
                hitAudioSource.Play();
            }

            if(windAudioSource)
            {
                windAudioSource.Stop();
            }

            if (hitParticleSystem)
            {
                hitParticleSystem.Play();
            }
        }
    }
}
