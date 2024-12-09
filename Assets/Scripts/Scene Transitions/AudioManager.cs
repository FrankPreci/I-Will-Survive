using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer audioMixer; // Reference to the Audio Mixer
    public string exposedParameter = "MasterVolume"; // The exposed parameter name in the mixer
    private float savedVolume; // Store the saved volume value

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure the AudioManager persists across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        // Load the saved volume value from PlayerPrefs (default to 1 if not saved)
        savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        audioMixer.SetFloat(exposedParameter, Mathf.Log10(savedVolume) * 20); // Apply saved volume to the mixer
    }

    // Method to adjust the volume and save the value
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(exposedParameter, Mathf.Log10(volume) * 20);
        savedVolume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume); // Save the volume setting to PlayerPrefs
    }

    void OnDisable()
    {
        // Save volume when the AudioManager is disabled (scene change)
        PlayerPrefs.SetFloat("MasterVolume", savedVolume);
    }
}
