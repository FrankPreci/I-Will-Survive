using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //will be worked on once we have something to attach it to.
    public PowerUpEffect upgrade;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            upgrade.Apply(collision.gameObject);
        }
    }
}
