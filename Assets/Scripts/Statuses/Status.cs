using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status
{
    protected float startTime;
    protected float duration = 10;
    protected HealthController characterHealthController;

    protected Status(float newDuration, HealthController healthController)
    {
        startTime = Time.time;
        duration = newDuration;
        characterHealthController = healthController;
    }

    public abstract void UpdateStatus();

    public virtual bool HasHealthBarColor()
    {
        return false;
    }

    public virtual Color GetHealthBarColor()
    {
        return new Color(0, 0, 0);
    }

    public bool IsExpired()
    {
        return Time.time - startTime >= duration;
    }
}
