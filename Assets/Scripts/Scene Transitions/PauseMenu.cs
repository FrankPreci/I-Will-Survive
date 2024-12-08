using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;     // Main Pause Menu UI
    public GameObject optionsPanelUI; // Options Panel UI

    private bool isPaused = false;

    void Update()
    {
        // Toggle pause menu when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Hide the pause menu
        Time.timeScale = 1f;          // Resume game time
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);  // Show the pause menu
        Time.timeScale = 0f;          // Freeze game time
        isPaused = true;
    }

    public void OpenOptions()
    {
        pauseMenuUI.SetActive(false);    // Hide the pause menu
        optionsPanelUI.SetActive(true); // Show the options panel
    }

    public void CloseOptions()
    {
        optionsPanelUI.SetActive(false); // Hide the options panel
        pauseMenuUI.SetActive(true);    // Show the pause menu
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
