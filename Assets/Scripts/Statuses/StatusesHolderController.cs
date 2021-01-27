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

    public void AddStatus(Status status)
    {
        Statuses.Add(status);
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
