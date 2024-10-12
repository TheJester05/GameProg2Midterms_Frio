using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for scene management
using UnityEngine.UI;  // Needed for UI components

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;  // Reference to the Game Over UI Panel

    void Start()
    {
        gameOverPanel.SetActive(false);  // Hide Game Over Panel initially
    }

    // Call this method to trigger game over
    public void TriggerGameOver()
    {
        gameOverPanel.SetActive(true);  // Show Game Over Panel
        Time.timeScale = 0;  // Pause the game
    }

    // Method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1;  // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }
}
