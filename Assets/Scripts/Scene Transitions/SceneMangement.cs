using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // UI references
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Slider volumeSlider;

    void Start()
    {
        // Set the initial volume based on saved data (if any)
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    // Play button action
    public void PlayGame()
    {
        // Load the game scene or start the game logic
        SceneManager.LoadScene("Game"); // Replace with your scene name
    }

    // Options button action
    public void ShowOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    // Quit button action
    public void QuitGame()
    {
        Application.Quit();
    }

    // Volume slider action
    private void OnVolumeChange(float value)
    {
        AudioListener.volume = value;
    }

    // Back button action
    public void BackToMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}