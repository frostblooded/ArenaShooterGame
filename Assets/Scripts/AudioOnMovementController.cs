using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnMovementController : MonoBehaviour
{
    public Transform objectTransform;

    AudioSource audioSource;
    Vector3 previousPosition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        previousPosition = objectTransform.position;
    }

    void Update()
    {
        Vector3 movement = previousPosition - objectTransform.position;
        bool isMoving = movement.magnitude > 0;
        Debug.Log(movement.magnitude);

        if(isMoving)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if(audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        previousPosition = objectTransform.position;
    }
}
