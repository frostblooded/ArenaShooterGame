using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 15f;

    [HideInInspector]
    // We expect this to be a normalized vector.
    public Vector3 direction;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position += direction * speed * Time.deltaTime;
    }
}
