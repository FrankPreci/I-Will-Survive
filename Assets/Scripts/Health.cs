using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is for health bar ui later

public class Health : MonoBehaviour
{
    public float maxHealth = 100f; //100health
    public float currentHealth; // gets current health
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        //When we have health bar UI
        if(currentHealth <= 0)
            {
                currentHealth = 0; // can't go negative.
                //updateHealthBar();
                Die();
            }

    }

    public void Heal (float amount)
    {
        currentHealth += amount;
        if ( currentHealth > maxHealth)
            currentHealth = maxHealth;  // conditions to make sure character doesnt get more health than he can
        //UpdateHealthBar();
    }

    /*private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
    */
    private void Die()
    {
        Debug.Log ("I did not survive.");
    }
}