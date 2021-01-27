using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueHat : MonoBehaviour
{
    public float secondsBeforeDestroy = 10;
    public ParticleSystem plagueParticleSystem;
    public float plagueRadius = 4;

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

    // Start is called before the first frame update
    void Start()
    {
        plagueParticleSystem.Play();
        StartCoroutine(DestroyAfterSeconds(secondsBeforeDestroy));
        ApplyPlague();
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
