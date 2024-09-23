using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;     // The player's transform (reference to the player's position)
    public Vector3 offset;       // Offset of the camera relative to the player
    public float smoothSpeed = 0.125f;  // Adjusts how smooth the camera follows the player

    void FixedUpdate()
    {
        // Desired position of the camera (player's position + offset)
        Vector3 newPos = player.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPos, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }

}
