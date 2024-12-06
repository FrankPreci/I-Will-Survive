using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float pullRange = 5f;         // Range within which the magnet effect is active
    public float pullSpeed = 2f;        // Speed at which objects are pulled towards the player

    void Update()
    {
        // Find all objects with the "XP" tag
        GameObject[] xpObjects = GameObject.FindGameObjectsWithTag("XP");

        foreach (GameObject xp in xpObjects)
        {
            if (xp == null) continue;

            // Calculate distance between player and XP object
            float distanceToXP = Vector3.Distance(transform.position, xp.transform.position);

            // Check if the XP object is within the pull range
            if (distanceToXP <= pullRange)
            {
                // Move the XP object towards the player
                xp.transform.position = Vector3.MoveTowards(
                    xp.transform.position,
                    transform.position,
                    pullSpeed * Time.deltaTime
                );
            }
        }
    }
}
