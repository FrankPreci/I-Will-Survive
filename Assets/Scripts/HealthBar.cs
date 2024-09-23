using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required to access the UI components

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;   // Reference to the UI slider

    // Method to set the max health value of the slider
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    // Method to update the slider with the current health value
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}
