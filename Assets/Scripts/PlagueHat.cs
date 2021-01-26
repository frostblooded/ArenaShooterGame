using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueHat : MonoBehaviour
{
    public float secondsBeforeDestroy = 10;
    public ParticleSystem plagueParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        plagueParticleSystem.Play();
        StartCoroutine(DestroyAfterSeconds(secondsBeforeDestroy));
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
