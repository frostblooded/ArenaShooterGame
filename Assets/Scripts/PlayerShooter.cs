using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform shotSource;
    public GameObject plagueHatProjectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Projectile plagueHatProjectile = Instantiate(plagueHatProjectilePrefab, shotSource.position, Quaternion.LookRotation(cameraTransform.forward)).GetComponent<Projectile>();
            plagueHatProjectile.direction = cameraTransform.forward;
        }
    }
}
