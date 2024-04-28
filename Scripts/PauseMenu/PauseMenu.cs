using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TMP_Text pauseText;

    private bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure the pause menu is initially hidden
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (isPaused && Input.GetKeyDown(KeyCode.LeftShift))
        {
            ReturnToMenu();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game
            pauseText.text = "Game Paused"; // Display pause text
        }
        else
        {
            Time.timeScale = 1f; // Resume normal time scale
        }
    }

    private void ReturnToMenu()
    {
        Time.timeScale = 1f; // Ensure time scale is normal
        SceneManager.LoadScene("MenuScene"); // Replace "MenuScene" with the name of your menu scene
    }
}
