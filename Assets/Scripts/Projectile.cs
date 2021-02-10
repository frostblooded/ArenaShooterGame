using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 15f;

    public float initalForceMultiplier = 5;

    [HideInInspector]
    public Vector3 direction;

    private void Start()
    {
        direction.Normalize();

        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(direction * initalForceMultiplier, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        // transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        // transform.position += direction * speed * Time.deltaTime;
    }
}
