using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : Projectile
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            gameObject.AddComponent<PlagueHat>();
            Destroy(this);
        }
    }
}
