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

        if (currentHealth <= 0)
        {
            currentHealth = 0; // can't go negative.
            Die();
        }
        updateHealthText();
    }

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