using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPLeveling : MonoBehaviour
{
    public Slider expSlider;   // Reference to the UI slider
    // Method to set the max exp value of the slider
    public void SetMaxEXP(int maxEXP)
    {
        expSlider.maxValue = maxEXP;
        expSlider.value = 0;
    }

    // Method to update the slider with the current exp value
    public void SetEXP(int currentEXP)
    {
        expSlider.value = currentEXP;
    }
}