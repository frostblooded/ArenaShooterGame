using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueHat : MonoBehaviour
{
    public ParticleSystem plagueParticleSystem;
    public ParticleSystem confettiParticleSystem;

    public AudioSource partyHornAudioSource;
    public AudioSource steamHissAudioSource;

    public float secondsBeforeDestroy = 10;
    public float plagueRadius = 4;
    public float hatTopThrowStrength = 3;

    public float plagueDuration = 5;
    public int plagueDamage = 1;
    public float plagueTickCooldown = 1;

    void ApplyPlague()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, plagueRadius);

        foreach(Collider collider in hits)
        {
            StatusesHolderController statusHolder = collider.GetComponent<StatusesHolderController>();
            HealthController healthController = collider.GetComponent<HealthController>();

            if(statusHolder && healthController)
            {
                statusHolder.AddStatus(new PlagueStatus(plagueDuration, healthController, plagueDamage, plagueTickCooldown));
            }
        }
    }

    IEnumerator SprayPlague()
    {
        yield return new WaitForSeconds(0.5f);

        ApplyPlague();
        partyHornAudioSource.Play();
        steamHissAudioSource.Play();

        plagueParticleSystem.Play();
        confettiParticleSystem.Play();

        StartCoroutine(StopHiss());
    }

    IEnumerator StopHiss()
    {
        yield return new WaitForSeconds(plagueParticleSystem.main.duration);
        steamHissAudioSource.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds(secondsBeforeDestroy));
        StartCoroutine(SprayPlague());
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    // Show plague cloud radius in the inspector visually
    private void OnDrawGizmosSelected()
    {
        // Plague purple color
        Gizmos.color = new Color(91, 31, 255);
        Gizmos.DrawWireSphere(transform.position, plagueRadius);
    }
}
