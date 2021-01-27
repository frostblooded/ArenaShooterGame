using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarColorer : MonoBehaviour
{
    public StatusesHolderController statusHolder;

    Image healthBarImage;
    Color originalColor;

    Color GetStatusesColor()
    {
        foreach(Status status in statusHolder.Statuses)
        {
            if(status.HasHealthBarColor())
            {
                return status.GetHealthBarColor();
            }
        }

        return originalColor;
    }

    private void Start()
    {
        healthBarImage = GetComponent<Image>();
        originalColor = healthBarImage.color;
    }

    void Update()
    {
        healthBarImage.color = GetStatusesColor();
    }
}
