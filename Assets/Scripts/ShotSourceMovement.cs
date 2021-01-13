using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSourceMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public float distance;

    void Update()
    {
        transform.position = cameraTransform.position + cameraTransform.forward.normalized * distance;
    }
}
