using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    [HideInInspector]
    public Vector3 direction;

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
