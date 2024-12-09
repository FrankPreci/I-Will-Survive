using UnityEngine;

public class Q_Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Reference to the circle projectile prefab
    public int numberOfProjectiles = 6;  // Number of projectiles in the ring
    public float radius = 3f;         // Radius of the ring
    public float fireRate = 3f;  // Time interval between shots
    public float bulletLifeTime = 2f;
    public float projectileSpeed = 50f; // Speed of the projectiles
    private float nextFireTime = 100f;
    //private bool isAlive = true;

    private void Start()
    {
        // Start shooting periodically
        InvokeRepeating("ShootRingOfCircles", 0f, fireRate);
    }
    
    void update() {
        if (Time.time > nextFireTime)
        {
            ShootRingOfCircles();
            nextFireTime = Time.time + 1f / fireRate; // Set the next time the enemy can fire
        }
    }

    private void ShootRingOfCircles()
    {
        // Calculate the angle between each projectile in the ring
        float angleStep = 360f / numberOfProjectiles;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            // Calculate the angle for this projectile
            float angle = i * angleStep;
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

            // Create the circle projectile at the enemy's position
            GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            
            // Apply the calculated direction and move the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed;
            }
        }
    }
    public void StopShooting()
    {
        //isAlive = false;  // Set the flag to false to stop shooting
        CancelInvoke("ShootRingOfCircles");  // Stop the repeating invocations of ShootRingOfCircles
    }
}