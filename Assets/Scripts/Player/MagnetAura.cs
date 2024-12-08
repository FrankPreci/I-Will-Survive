using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float pullRange = 10f;         // Range within which the magnet effect is active
    public float pullSpeed = 10f;        // Speed at which objects are pulled towards the player

    void Update()
    {
        // Find all objects with the "XP" tag
        GameObject[] xpObjects = GameObject.FindGameObjectsWithTag("XP");
        GameObject[] hpObjects = GameObject.FindGameObjectsWithTag("HP");

        // Process XP objects
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

        // Process HP objects
        foreach (GameObject hp in hpObjects)
        {
            if (hp == null) continue;

            // Calculate distance between player and HP object
            float distanceToHP = Vector3.Distance(transform.position, hp.transform.position);

            // Check if the HP object is within the pull range
            if (distanceToHP <= pullRange)
            {
                // Move the HP object towards the player
                hp.transform.position = Vector3.MoveTowards(
                    hp.transform.position,
                    transform.position,
                    pullSpeed * Time.deltaTime
                );
            }
        }
    }

    public void IncreasePullRange(float amount)
    {
        pullRange += amount;
        Debug.Log("New Magnet Pull Range: " + pullRange);
    }
}