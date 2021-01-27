using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardWorldSpaceUIController : MonoBehaviour
{
    Transform cameraTransform;

    Quaternion originalRotation;

    void Start()
    {
        cameraTransform = FindObjectOfType<Camera>().transform;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = cameraTransform.rotation * originalRotation;
    }
}
