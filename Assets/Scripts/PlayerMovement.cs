using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;           // Speed of the player
    public Rigidbody2D rb;                 // Reference to the player's Rigidbody2D component

    private Vector2 movement;              // Stores movement direction
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Input detection (WASD or Arrow Keys)
        movement.x = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right Arrow
        movement.y = Input.GetAxisRaw("Vertical");    // W/S or Up/Down Arrow
    }

    void FixedUpdate()
    {
        // Move the player with Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
