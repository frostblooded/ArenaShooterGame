using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform shotSource;
    public GameObject plagueHatProjectilePrefab;

    // We need this function so that we can find out in what direction do we need to shoot
    // from the shot source object so that the projectile goes in the direction that the
    // user wanted based on his crosshair.
    Vector3 GetThrowMovement()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;
        const float MAX_DIST = 1000;

        // If there is an object in front of the crosshair, move towards it.
        if(Physics.Raycast(ray, out hit, MAX_DIST))
        {
            return (hit.point - shotSource.position).normalized;
        }
        // Otherwise, just move towards a point that is MAX_DIST forward from the crosshair
        // and in its direction.
        else
        {
            return (cameraTransform.forward * MAX_DIST - shotSource.position).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Projectile plagueHatProjectile = Instantiate(plagueHatProjectilePrefab, shotSource.position, Quaternion.LookRotation(cameraTransform.forward)).GetComponent<Projectile>();
            plagueHatProjectile.direction = GetThrowMovement();
        }
    }
}
