using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : Projectile
{
    public GameObject stickedObjectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(stickedObjectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
