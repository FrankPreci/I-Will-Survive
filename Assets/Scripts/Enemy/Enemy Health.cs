using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; //100health
    public int currentHealth; // gets current health
    //public GameObject dmgSource;
    public GameObject xpPotionPrefab;
    public GameObject healthPotionPrefab; // Reference to the health potion prefab
    private float healthPotionDropChance = 0.1f; // 10% chance

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
            TakeDamage(10);
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
        // 20% chance to drop a health potion
        if (healthPotionPrefab != null && Random.value <= healthPotionDropChance)
        {
            Instantiate(healthPotionPrefab, transform.position, Quaternion.identity);
        }
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
