using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // This is for health bar ui later
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; //100health
    public int currentHealth; // gets current health
    //public GameObject dmgSource;
    public HealthBar healthBar;
    public Timer timer;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //Screen_HP.SetMaxHealth(maxHealth);
        updateHealthText();

    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
        updateHealthText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
        if (collision.tag == "Bullet")
        {
            TakeDamage(10);
            Destroy(collision.GameObject());
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        updateHealthText();
        //Screen_HP.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0; // can't go negative.
            Die();
        }
    }
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount; // Increase max health
        currentHealth += amount; // Restore extra health up to the new max
        healthBar.SetMaxHealth(maxHealth);
        updateHealthText();

        Debug.Log($"Max health increased to {maxHealth}. Current health: {currentHealth}");
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
        timer.StopTimer();
    }
    public void updateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth + " / " + maxHealth;
        }
    }
}