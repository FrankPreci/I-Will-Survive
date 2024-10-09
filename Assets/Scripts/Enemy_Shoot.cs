using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject player;          // The player object
    public GameObject bulletPrefab;    // The bullet prefab to shoot
    public Transform firePoint;        // Where the bullets will be fired from
    public float bulletSpeed = 30f;    // Speed of the bullets
    public float fireRate = 1.0f;      // How often the enemy fires
    public float bulletLifeTime = 3f;
    private float nextFireTime = 0f;   // Keeps track of when the enemy can fire again

    private void Start()
    {
        player = GameObject.Find("Character-i");
    }
    // Update is called once per frame
    void Update()
    {
        // Lock the enemy's rotation toward the player
        LockOnPlayer();

        // Check if the enemy can shoot
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Set the next time the enemy can fire
        }
    }

    void LockOnPlayer()
    {
        // Calculate the direction from the enemy to the player
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Calculate the angle to rotate the enemy towards the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the enemy to face the player
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    void Shoot()
    {
        // Create a bullet at the firePoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity to move towards the player
        Vector2 shootDirection = (player.transform.position - firePoint.position).normalized;
        rb.velocity = shootDirection * bulletSpeed;

        Destroy(bullet,bulletLifeTime);
    }
}