using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_HP : MonoBehaviour
{
    public Slider healthSlider;   // Reference to the UI slider
    // Method to set the max health value of the slider
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        // healthSlider2.maxValue = health;
        healthSlider.value = health;
        //healthSlider2.value = health;
    }

    // Method to update the slider with the current health value
    public void SetHealth(int health)
    {
        healthSlider.value = health;
        //healthSlider2.value = health;
    }
}
