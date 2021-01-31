using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusesHolderController : MonoBehaviour
{
    List<Status> statusesToRemove;

    public List<Status> Statuses
    {
        get;
        private set;
    }

    // As of now there can only ever be one status from each type,
    // so we check if we should replace a status that already exists
    // or add a new status.
    public void AddStatus<T>(T newStatus)
        where T: Status
    {
        int sameStatusIndex = Statuses.FindIndex(x => x is T);

        if(sameStatusIndex >= 0)
        {
            Statuses[sameStatusIndex] = newStatus;
        }
        else
        {
            Statuses.Add(newStatus);
        }
    }

    void Start()
    {
        Statuses = new List<Status>();
        statusesToRemove = new List<Status>();
    }

    void Update()
    {
        foreach(Status status in Statuses)
        {
            if(status.IsExpired())
            {
                statusesToRemove.Add(status);
            }
            else
            {
                status.UpdateStatus();
            }
        }

        foreach(Status status in statusesToRemove)
        {
            Statuses.Remove(status);
        }
    }
}
