using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required to access the UI components

public class HealthBar : MonoBehaviour
{
    public Slider attachedSlider;   // Reference to the UI slider
    public Slider ScreenSlider;
    //public Slider healthSlider2;
    // Method to set the max health value of the slider
    public void SetMaxHealth(int health)
    {
        attachedSlider.maxValue = health;
        attachedSlider.value = health;

        ScreenSlider.maxValue = health;
        ScreenSlider.value = health;
    }

    // Method to update the slider with the current health value
    public void SetHealth(int health)
    {
        attachedSlider.value = health;

        ScreenSlider.value = health;
    }
}
