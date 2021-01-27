using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueStatus : Status
{
    int damage;

    float tickCooldown;
    float lastTick;

    public PlagueStatus(float newDuration, HealthController healthController, int damage, float tickCooldown)
        : base(newDuration, healthController)
    {
        this.damage = damage;
        lastTick = Time.time;
        this.tickCooldown = tickCooldown;
    }

    public override void UpdateStatus()
    {
        if(Time.time - lastTick >= tickCooldown)
        {
            characterHealthController.Damage(damage);
            lastTick = Time.time;
        }
    }

    public override bool HasHealthBarColor()
    {
        return true;
    }

    public override Color GetHealthBarColor()
    {
        // Purple
        return new Color(91f / 255, 31f / 255, 255f / 255);
    }
}
