using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required to access the UI components

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;   // Reference to the UI slider
    public Slider healthSlider2;
    // Method to set the max health value of the slider
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider2.maxValue = health;
        healthSlider.value = health;
        healthSlider2.value = health;
    }

    // Method to update the slider with the current health value
    public void SetHealth(int health)
    {
        healthSlider.value = health;
        healthSlider2.value = health;
    }
}
