using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    // UI references
    public GameObject mainMenu;

    // Play button action
    public void PlayGame()
    {
        // Load the game scene or start the game logic
        SceneManager.LoadScene("Game"); // Replace with your scene name
    }

     public void GameMenu()
    {
        // Load the game scene or start the game logic
        SceneManager.LoadScene(0); // Replace with your scene name
    }
}