using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerMovement : MonoBehaviour
{
    //HP will be set for each entity in this case the player
    public int maxHealth = 100;
    public int currentHealth;
    public Health healthBar;
    //movement speed
    public float horizontalSpeed = 60f;        
    public float verticalSpeed = 40f;
    private Rigidbody2D rb;                 // Reference to the player's Rigidbody2D component
    private Vector2 movement;              // Stores movement direction

    [SerializeField] public int dmgTaken = 20; //For testing only
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHP(maxHealth);
    }
    void Update()
    {
        // Input detection (WASD or Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right Arrow
        float moveY = Input.GetAxisRaw("Vertical");    // W/S or Up/Down Arrow

        Vector2 movement = new Vector2(moveX * horizontalSpeed, moveY * verticalSpeed);

        rb.velocity = movement;

        //Testing DMG
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(dmgTaken);
        }
    }
    void TakeDamage(int dmg){
        currentHealth-=dmg;
        healthBar.SetHP(currentHealth);
    }

}
