using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{
    public float horizontalSpeed = 2f;        
    public float verticalSpeed = 2f;
    private Rigidbody2D rb;                 // Reference to the player's Rigidbody2D component
    private Vector2 movement;              // Stores movement direction

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Input detection (WASD or Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right Arrow
        float moveY = Input.GetAxisRaw("Vertical");    // W/S or Up/Down Arrow

        Vector2 movement = new Vector2(moveX * horizontalSpeed, moveY * verticalSpeed);

        rb.velocity = movement;

    }


}
