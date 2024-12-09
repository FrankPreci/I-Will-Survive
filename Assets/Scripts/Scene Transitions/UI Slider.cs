using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Initialize the slider value based on saved volume from PlayerPrefs
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged); // Listen for slider value change
    }

    // This function is called when the slider value changes
    public void OnVolumeChanged(float value)
    {
        // Use AudioManager to set the volume
        AudioManager.instance.SetVolume(value);
    }
}
