using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bulletPrefab;
    public Transform bulletTransform;
    public bool canFire =true;
    public float fireRate = 1f;
    public float timeBetweenFiring = 1f;
    public float bulletSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        LockOntoMouse();
        
        if (Time.time > timeBetweenFiring && Input.GetMouseButtonDown(0))
        {
            Shoot();
            timeBetweenFiring = Time.time + 1f/ fireRate; // Set the next time the enemy can fire
        }
    }
    void LockOntoMouse()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    void Shoot()
    {
        // Create a bullet at the bulletTransform's position and rotation
        GameObject bullet = Instantiate( bulletPrefab, bulletTransform.position, bulletTransform.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity to move towards the player
        Vector2 shootDirection = (mousePos - bulletTransform.position).normalized;
        rb.velocity = shootDirection * bulletSpeed;

        Destroy(bullet, 4);
    }

}
