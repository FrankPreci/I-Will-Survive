using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is for health bar ui later

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; //100health
    public float currentHealth; // gets current health
    public float damageTaken = 20;
    
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damageTaken);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
            {
                currentHealth = 0; // can't go negative.
                Die();
            }

    }

    // public void Heal (float amount)
    // {
    //     currentHealth += amount;
    //     if ( currentHealth > maxHealth)
    //         currentHealth = maxHealth;  // conditions to make sure character doesnt get more health than he can
    //     //UpdateHealthBar();
    // }

    /*private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
    */
    private void Die()
    {
        //Destroy asset or whatever its called
        Debug.Log ("I did not survive.");
        gameObject.SetActive(false);
    }
}