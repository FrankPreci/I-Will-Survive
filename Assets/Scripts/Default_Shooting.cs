using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Default_Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Reference to the bullet prefab
    public float bulletSpeed = 4f;   // Speed of the bullet
    public float fireRate = 0.5f;     // Time between shots

    private float nextFireTime = 1f;  // Time until the next shot can be fired

    void Update()
    {
        // Check if it's time to shoot
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;  // Schedule next shot
        }
    }

    void Shoot()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z to 0 for 2D games (or adjust for 3D)

        // Calculate the direction to shoot the bullet
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        // Create the bullet instance
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Set the bullet's velocity (for Rigidbody2D)
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * bulletSpeed;

        // Optional: Destroy the bullet after a certain time to prevent clutter
        Destroy(bullet, 2.5f); // time to destory
    }
}
