using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;     // The player's transform (reference to the player's position)
    public Vector3 offset;       // Offset of the camera relative to the player
    public float smoothSpeed = 0.125f;  // Adjusts how smooth the camera follows the player


        private void Start()
    {
        player = GameObject.Find("Character-i").transform;
    }
  
    void Update()
    {
        // If the target is set, update the camera position to the target's position + offset
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
   

}
