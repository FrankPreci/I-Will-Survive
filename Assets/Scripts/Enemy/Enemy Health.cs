using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; //100health
    public int currentHealth; // gets current health
    //public GameObject dmgSource;
    public GameObject xpPotionPrefab;
    void Start()
    {
        currentHealth = maxHealth;

    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0; // can't go negative.
            Die();
        }
    }

    private void DropXpPotion()
    {
        if( xpPotionPrefab != null)
        {
            GameObject xpPotion = Instantiate(xpPotionPrefab, transform.position, Quaternion.identity);   
        }
    }

    private void Die()
    {
        //Destroy asset or whatever its called
        gameObject.SetActive(false);
        DropXpPotion();
    }
}
